using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data;
using NF.Core;
using System.Data.SqlClient;
using System.Configuration;

namespace newsflippers
{
    /// <summary>
    /// Summary description for NFService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class NFService : System.Web.Services.WebService
    {

        [WebMethod]
        public void AddNewsItems(DataTable dt)
        {
            try
            {
                InsertSourceItem(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetConnectionString() {
            return Infonex.Security.Encrypter.DecryptString(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        }

        public static void InsertSourceItem(DataTable dt)
        {

            SqlConnection cnn = new SqlConnection(GetConnectionString());
            SqlCommand cmd = new SqlCommand("INSERT_SOURCE_ITEMS_1", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cnn.Open();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                cmd.Parameters.AddWithValue("@SRC_LNK_ID", row["SRC_LNK_ID"]);
                cmd.Parameters.AddWithValue("@ITM_TITLE", row["ITM_TITLE"]);
                cmd.Parameters.AddWithValue("@ITM_URL", row["ITM_URL"]);
                cmd.Parameters.AddWithValue("@ITM_CAT", row["ITM_CAT"]);
                cmd.Parameters.AddWithValue("@ITM_DESC", row["ITM_DESC"]);
                cmd.Parameters.AddWithValue("@ITM_PUBDATE", row["ITM_PUBDATE"]);
                cmd.Parameters.AddWithValue("@ITM_ADDEDDATE", row["ITM_ADDEDDATE"]);
                cmd.Parameters.AddWithValue("@ITM_DATEREF", row["ITM_DATEREF"]);
                cmd.Parameters.AddWithValue("@ITM_IMGNAME", row["ITM_IMGNAME"]);
                cmd.Parameters.AddWithValue("@ITM_IMGTHUMB", row["ITM_IMGTHUMB"]);
                cmd.Parameters.AddWithValue("@ITM_IMAGE", row["ITM_IMAGE"]);
                cmd.Parameters.AddWithValue("@ITM_FAILED", row["ITM_FAILED"]);

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            cnn.Close();
        }
           
    }
}
