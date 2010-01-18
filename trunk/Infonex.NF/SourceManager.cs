using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Infonex.NF.Core {
    public class SourceManager {
        public static void CreateSource(Source source) {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@SRC_NAME", source.Name);
            cmd.Parameters.AddWithValue("@SRC_URL", source.Url);
            cmd.Parameters.AddWithValue("@SRC_ACTIVE", source.Active);
            cmd.Parameters.AddWithValue("@SRC_COUNTRY", source.Country);
            cmd.Parameters.AddWithValue("@SRC_SORTORDER", source.SortOrder);

            Database db = new Database();
            db.ExecuteNonQuery("USP_SOURCES_CREATE", cmd);
        }

        public static void CreateSourceLink(SourceLink sourceLink) {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@SRC_ID", sourceLink.SourceID);
            cmd.Parameters.AddWithValue("@CAT_ID", sourceLink.CateogryID);
            cmd.Parameters.AddWithValue("@SRC_LNE_URL", sourceLink.Url);
            cmd.Parameters.AddWithValue("@SRC_LNE_TITLE", sourceLink.Title);
            cmd.Parameters.AddWithValue("@SRC_LNE_ADDEDDATE", sourceLink.AddedDate);
            cmd.Parameters.AddWithValue("@SRC_LNE_ACTIVE", sourceLink.Active);

            Database db = new Database();
            db.ExecuteNonQuery("USP_SOURCES_LINK_CREATE", cmd);
        }

        public static void CreateSourceLinkImage(SourceLinkImage sourceLinkImg) {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@SRC_LNE_ID", sourceLinkImg.SourceLinkID);
            cmd.Parameters.AddWithValue("@SRC_ID", sourceLinkImg.SourceID);
            cmd.Parameters.AddWithValue("@CAT_ID", sourceLinkImg.CateogryID);
            cmd.Parameters.AddWithValue("@SRC_LNE_IMG_IMAGENAME", sourceLinkImg.ImageName);
            cmd.Parameters.AddWithValue("@SRC_LNE_IMG_TITLE", sourceLinkImg.Title);
            cmd.Parameters.AddWithValue("@SRC_LNE_IMG_URL", sourceLinkImg.Url);
            cmd.Parameters.AddWithValue("@SRC_LNE_IMG_DATEREF", sourceLinkImg.DateRef);
            cmd.Parameters.AddWithValue("@SRC_LNE_IMG_GENEREATEDATE", sourceLinkImg.GeneratedDate);

            Database db = new Database();
            db.ExecuteNonQuery("USP_SOURCES_LINK_IMAGES_CREATE", cmd);
        }

        public static void SourceSetStatus(int sourceId, bool active) {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@SRC_ID", sourceId);
            cmd.Parameters.AddWithValue("@ACTIVE", active);

            Database db = new Database();
            db.ExecuteNonQuery("USP_SOURCES_SET_ACTIVE", cmd);
        }

        public static List<SourceLinkImage> GetSourceLinkImages(int sourceId, string dateref) {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@DATEREF", dateref);
            cmd.Parameters.AddWithValue("@SRC_ID", sourceId);

            Database db = new Database();
            IDataReader rdr = db.ExecuteReader("USP_SOURCE_LINKS_IMAGES_GetBySourceAndDateRef", cmd);
            return GetSourcesLinkImagesReader(rdr);
        }

        public static List<SourceLinkImage> GetSourceLinkImagesByCategory(int catID, string dateref) {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@DATEREF", dateref);
            cmd.Parameters.AddWithValue("@CAT_ID", catID);

            Database db = new Database();
            IDataReader rdr = db.ExecuteReader("USP_SOURCE_LINKS_IMAGES_GetByCategory", cmd);
            return GetSourcesLinkImagesReader(rdr);
        }

        public static List<Source> GetSources(string country) {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@COUNTRY", country);

            Database db = new Database();
            IDataReader rdr = db.ExecuteReader("USP_SOURCE_GetData", cmd);
            return GetSources(rdr);
        }

        private static List<Source> GetSources(IDataReader rdr) {
            List<Source> sourceCollection = new List<Source>();
            while (rdr.Read()) {
                Source source = new Source();
                source.ID = Convert.ToInt32(rdr["SRC_ID"]);
                source.Name = rdr["SRC_ID"].ToString();
                source.Url = rdr["SRC_URL"].ToString();
                source.Country = rdr["SRC_COUNTRY"].ToString();
                source.Active = Convert.ToBoolean(rdr["SRC_ACTIVE"]);
                source.SortOrder = Convert.ToDouble(rdr["SRC_SORTORDER"]);
                sourceCollection.Add(source);
            }
            rdr.Close();
            return sourceCollection;
        }

        private static List<SourceLinkImage> GetSourcesLinkImagesReader(IDataReader rdr) {
            List<SourceLinkImage> sourceLinkImagesCollection = new List<SourceLinkImage>();
            while (rdr.Read()) {
                SourceLinkImage sourceLinkImage = new SourceLinkImage();
                sourceLinkImage.ID = Convert.ToInt32(rdr["SRC_LNE_IMG_ID"]);
                sourceLinkImage.SourceID = Convert.ToInt32(rdr["SRC_ID"]);
                sourceLinkImage.CateogryID = Convert.ToInt32(rdr["CAT_ID"]);
                sourceLinkImage.SourceLinkID = Convert.ToInt32(rdr["SRC_LNE_ID"]);
                sourceLinkImage.ImageName = rdr["SRC_LNE_IMG_IMAGENAME"].ToString();
                sourceLinkImage.Title = rdr["SRC_LNE_IMG_TITLE"].ToString();
                sourceLinkImage.Url = rdr["SRC_LNE_IMG_URL"].ToString();
                sourceLinkImage.GeneratedDate = Convert.ToDateTime(rdr["SRC_GENERATEDATE"]);
                sourceLinkImage.DateRef = rdr["SRC_LNE_IMG_DATEREF"].ToString();
                sourceLinkImagesCollection.Add(sourceLinkImage);
            }
            rdr.Close();
            return sourceLinkImagesCollection;
        }
    }
}
