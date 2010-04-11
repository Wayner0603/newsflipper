﻿//using System;
//using System.Collections.Generic;

//using System.Web;
//using System.Data;
//using System.Data.SqlClient;
//using Infonex;
//using System.IO;
//using System.Configuration;
//using System.Drawing;
//using System.Drawing.Drawing2D;
//using System.Drawing.Imaging;

//namespace newsflippers
//{
//    public class NewsManager
//    {
//        public static void InsertImage(int newsId, string imageName, string title, string url)
//        {
//            SqlCommand cmd = new SqlCommand();
//            cmd.Parameters.AddWithValue("@NMG_NPR_ID", newsId);
//            cmd.Parameters.AddWithValue("@NMG_SEC_ID", 0);
//            cmd.Parameters.AddWithValue("@NMG_ADDEDDATE", Utility.LocalDate());
//            cmd.Parameters.AddWithValue("@NMG_DATE", Utility.LocalDate().ToString("MMddyyyy"));
//            cmd.Parameters.AddWithValue("@NMG_URL", url);
//            cmd.Parameters.AddWithValue("@NMG_IMAGENAME", imageName);
//            cmd.Parameters.AddWithValue("@NMG_TITLE", title);
//            Infonex.Data.Database db = new Infonex.Data.Database();
//            db.ExecuteNonQuery("USP_NEWSPAPER_IMAGES_CREATE", cmd);
//        }

//        private static string GetConnectionString()
//        {
//            return Infonex.Security.Encrypter.DecryptString(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
//        }

//        //public static Stream GetPhoto(int photoid) {
//        //    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString)) {
//        //        using (SqlCommand command = new SqlCommand("USP_NEWSPAPER_GETIMAGE", connection)) {
//        //            command.CommandType = CommandType.StoredProcedure;
//        //            command.Parameters.Add(new SqlParameter("@NMG_ID", photoid));
//        //            connection.Open();
//        //            object result = command.ExecuteScalar();
//        //            try {
//        //                return new MemoryStream((byte[])result);
//        //            } catch {
//        //                return null;
//        //            }
//        //        }
//        //    }
//        //}

//        private static SqlDataReader ExecuteReader(string spName, SqlCommand cmd)
//        {
//            SqlConnection cnn = new SqlConnection(GetConnectionString());
//            cmd.CommandText = spName;
//            cmd.CommandType = CommandType.StoredProcedure;
//            cmd.Connection = cnn;
//            cnn.Open();
//            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
//        }


//        public static Source GetSource(int id)
//        {
//            Infonex.Data.Database db = new Infonex.Data.Database();
//            SqlCommand cmd = new SqlCommand();
//            cmd.Parameters.AddWithValue("@SRC_ID", id);
//            SqlDataReader rdr = ExecuteReader("USP_SOURCE_GETBYID", cmd);

//            List<Source> sourceList = new List<Source>();
//            while (rdr.Read())
//            {
//                sourceList.Add(new Source()
//                {
//                    ID = Convert.ToInt32(rdr["NPR_ID"]),
//                    Title = rdr["NPR_TITLE"].ToString(),
//                    Desc = rdr["NPR_DESC"].ToString(),
//                    Url = rdr["NPR_URL"].ToString(),
//                    Active = Convert.ToBoolean(rdr["NPR_ACTIVE"])
//                });
//            }
//            rdr.Close();
//            return sourceList[0];
//        }

//        public static List<Source> GetChildSources(Source source)
//        {
//            SqlCommand cmd = new SqlCommand();
//            Infonex.Data.Database db = new Infonex.Data.Database();
//            cmd.Parameters.AddWithValue("@NPR_PARENT_ID", source.ID);
//            IDataReader rdr = ExecuteReader("USP_SOURCES_GETCHILDSOURCES", cmd);
//            List<Source> sourceList = new List<Source>();
//            sourceList.Add(source);
//            while (rdr.Read())
//            {
//                sourceList.Add(new Source()
//                {
//                    ID = Convert.ToInt32(rdr["NPR_ID"]),
//                    Title = rdr["NPR_TITLE"].ToString(),
//                    Desc = rdr["NPR_DESC"].ToString(),
//                    Url = rdr["NPR_URL"].ToString(),
//                    Active = Convert.ToBoolean(rdr["NPR_ACTIVE"])
//                });
//            }
//            rdr.Close();
//            return sourceList;
//        }

//        public static DataSet GetNewsLinks()
//        {
//            SqlCommand cmd = new SqlCommand();
//            Infonex.Data.Database db = new Infonex.Data.Database();
//            return db.ExecuteDataSet("USP_NEWSPAPERS_GETALL", cmd);
//        }

//        public static DataSet GetImages()
//        {
//            SqlCommand cmd = new SqlCommand();
//            Infonex.Data.Database db = new Infonex.Data.Database();
//            return db.ExecuteDataSet("USP_NEWSPAPER_IMAGES_GETALL", cmd);
//        }

//        public static List<CaptureWebPage> GetCaptureWebPages()
//        {
//            return GetCaptureWebPages(Extensions.ToDateRef(Utility.LocalDate()));
//        }

//        public static List<CaptureWebPage> GetCaptureWebPages(string dt)
//        {
//            SqlCommand cmd = new SqlCommand();
//            cmd.Parameters.AddWithValue("@DATEREF", dt);
//            Infonex.Data.Database db = new Infonex.Data.Database();
//            IDataReader rdr = ExecuteReader("USP_NEWSPAPER_IMAGES_GETALL", cmd);
//            List<CaptureWebPage> childSources = new List<CaptureWebPage>();
//            while (rdr.Read())
//            {
//                childSources.Add(new CaptureWebPage()
//                {
//                    Title = rdr["NMG_TITLE"].ToString(),
//                    ImageName = rdr["NMG_IMAGENAME"].ToString(),
//                    Url = rdr["NMG_URL"].ToString()
//                });
//            }
//            rdr.Close();
//            return childSources;
//        }

//        public static void InsertIssue(string issueText)
//        {
//            SqlConnection cnn = new SqlConnection(GetConnectionString());
//            SqlCommand cmd = new SqlCommand("USP_ISSUES_INSERT", cnn);
//            cmd.CommandType = CommandType.StoredProcedure;
//            cmd.Parameters.AddWithValue("@ISS_TEXT", issueText);
//            cmd.Parameters.AddWithValue("@ISS_DATE", DateTime.UtcNow);
//            cnn.Open();
//            cmd.ExecuteNonQuery();
//            cnn.Close();
//        }

//        public static bool IsImageExists(string imageName)
//        {
//            SqlCommand cmd = new SqlCommand();
//            cmd.Parameters.AddWithValue("@NMG_IMAGENAME", imageName);
//            cmd.Parameters.AddWithValue("@NMG_DATE", imageName);
//            Infonex.Data.Database db = new Infonex.Data.Database();
//            IDataReader rdr = ExecuteReader("USP_NEWSPAPER_IMAGES_RECORDEXISTS", cmd);
//            bool imageExist = false;
//            while (rdr.Read())
//            {
//                imageExist = true;
//            }
//            rdr.Close();
//            return imageExist;
//        }


//        public static List<Source> GetSources()
//        {
//            SqlCommand cmd = new SqlCommand();
//            Infonex.Data.Database db = new Infonex.Data.Database();
//            IDataReader rdr = ExecuteReader("USP_SOURCES_GETALL", cmd);
//            List<Source> sourceList = new List<Source>();
//            while (rdr.Read())
//            {
//                sourceList.Add(new Source()
//                {
//                    ID = Convert.ToInt32(rdr["NPR_ID"]),
//                    Title = rdr["NPR_TITLE"].ToString(),
//                    Desc = rdr["NPR_DESC"].ToString(),
//                    Url = rdr["NPR_URL"].ToString(),
//                    Active = Convert.ToBoolean(rdr["NPR_ACTIVE"])
//                });
//            }
//            rdr.Close();
//            return sourceList;
//        }

//        public static List<Source> GetAllSources()
//        {
//            SqlCommand cmd = new SqlCommand();
//            Infonex.Data.Database db = new Infonex.Data.Database();
//            IDataReader rdr = ExecuteReader("USP_NEWSPAPERS_GETALL", cmd);
//            List<Source> sourceList = new List<Source>();
//            while (rdr.Read())
//            {
//                sourceList.Add(new Source()
//                {
//                    ID = Convert.ToInt32(rdr["NPR_ID"]),
//                    ParentID = Convert.ToInt32(rdr["NPR_PARENT_ID"]),
//                    Title = rdr["NPR_TITLE"].ToString(),
//                    Desc = rdr["NPR_DESC"].ToString(),
//                    Url = rdr["NPR_URL"].ToString(),
//                    Active = Convert.ToBoolean(rdr["NPR_ACTIVE"])
//                });
//            }
//            rdr.Close();
//            return sourceList;
//        }

//        private static byte[] ResizeImageFile(byte[] imageFile, int targetSize)
//        {
//            using (System.Drawing.Image oldImage = System.Drawing.Image.FromStream(new MemoryStream(imageFile)))
//            {
//                Size newSize = CalculateDimensions(oldImage.Size, targetSize);
//                using (Bitmap newImage = new Bitmap(newSize.Width, newSize.Height, PixelFormat.Format24bppRgb))
//                {
//                    using (Graphics canvas = Graphics.FromImage(newImage))
//                    {
//                        canvas.SmoothingMode = SmoothingMode.AntiAlias;
//                        canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
//                        canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;
//                        canvas.DrawImage(oldImage, new Rectangle(new Point(0, 0), newSize));
//                        MemoryStream m = new MemoryStream();
//                        newImage.Save(m, ImageFormat.Jpeg);
//                        return m.GetBuffer();
//                    }
//                }
//            }
//        }

//        private static Size CalculateDimensions(Size oldSize, int targetSize)
//        {
//            Size newSize = new Size();
//            if (oldSize.Height > oldSize.Width)
//            {
//                newSize.Width = (int)(oldSize.Width * ((float)targetSize / (float)oldSize.Height));
//                newSize.Height = targetSize;
//            }
//            else
//            {
//                newSize.Width = targetSize;
//                newSize.Height = (int)(oldSize.Height * ((float)targetSize / (float)oldSize.Width));
//            }
//            return newSize;
//        }
//    }
//}
