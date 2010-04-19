using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data;
using NF.Engine;
using System.Data.SqlClient;
using System.Configuration;

namespace newsflippers
{
    /// <summary>
    /// Summary description for NFService
    /// </summary>
    [WebService(Namespace = "http://www.newsflippers.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class NFService : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetName()
        {
            return "Ludmal" ;
        }

        [WebMethod]
        public string AddNewsItems(DataTable dt)
        {
            try
            {
                //InsertSourceItem(dt);
                return "done";

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            return "nothin happend";
        }

        public static string GetConnectionString()
        {
            //return @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=NF_2;Data Source=LUDMAL_PC";

            return @"Data Source=winsqlus03.lxa.perfora.net,1433;Initial Catalog=db311835257;User Id=dbo311835257;Password=thu$hari78-$@";
        }

        [WebMethod]
        public void InsertSourceItem(string name)
        {

            SqlConnection cnn = new SqlConnection(@"Data Source=winsqlus03.lxa.perfora.net,1433;Initial Catalog=db311835257;User Id=dbo311835257;Password=thu$hari78-$@");
            SqlCommand cmd = new SqlCommand("INSERT_SOURCE_ITEMS_1", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cnn.Open();

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
                //DataRow row = dt.Rows[i];
                cmd.Parameters.AddWithValue("@SRC_LNK_ID", 1);
                cmd.Parameters.AddWithValue("@ITM_TITLE", name);
                cmd.Parameters.AddWithValue("@ITM_URL", name);
                cmd.Parameters.AddWithValue("@ITM_CAT", name);
                cmd.Parameters.AddWithValue("@ITM_DESC", name);
                cmd.Parameters.AddWithValue("@ITM_PUBDATE", DateTime.Now );
                cmd.Parameters.AddWithValue("@ITM_ADDEDDATE", DateTime.Now );
                cmd.Parameters.AddWithValue("@ITM_DATEREF", "2323");
                cmd.Parameters.AddWithValue("@ITM_IMGNAME", "sds");
                cmd.Parameters.AddWithValue("@ITM_IMGTHUMB", "");
                cmd.Parameters.AddWithValue("@ITM_IMAGE", true);
                cmd.Parameters.AddWithValue("@ITM_FAILED", 0);

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
           // }
            cnn.Close();
        }

    }
}
