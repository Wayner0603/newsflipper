using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Infonex.NF.Core {
    public class Database {
        private string _ConnectionKey = "con";
        public Database(string connectionKey) {
            if (!string.IsNullOrEmpty(_ConnectionKey))
                _ConnectionKey = connectionKey;
        }

        public Database()
            : this("") {

        }

        private string GetConnectionString() {
            return ConfigurationManager.ConnectionStrings[_ConnectionKey].ConnectionString ;
        }

        #region ExecuteReader
        public IDataReader ExecuteReader(string sql, SqlCommand cmd, CommandType commandType) {
            SqlConnection cnn = new SqlConnection(GetConnectionString());
            try {
                if (cmd == null) {
                    cmd = new SqlCommand();
                }
                cmd.Connection = cnn;
                cmd.CommandText = sql;
                cmd.CommandType = commandType;
                cnn.Open();
                IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return reader;
            } catch (Exception ex) {
                throw ex;
            } finally {
                //cnn.Close();
            }
        }

        public IDataReader ExecuteReader(string spName, SqlCommand cmd) {
            return ExecuteReader(spName, cmd, CommandType.StoredProcedure);
        }

        public IDataReader ExecuteReader(string sqlText) {
            return ExecuteReader(sqlText, null, CommandType.Text);
        }

        #endregion

        #region ExecuteScalar
        public int ExecuteScalar(string sql, SqlCommand cmd, CommandType commandType) {
            SqlConnection cnn = new SqlConnection(GetConnectionString());
            try {
                if (cmd == null) {
                    cmd = new SqlCommand();
                }
                cmd.Connection = cnn;
                cmd.CommandText = sql;
                cmd.CommandType = commandType;
                cnn.Open();
                int returnValue = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Parameters.Clear();
                return returnValue;
            } catch (Exception ex) {
                throw ex;
            } finally {
                cnn.Close();
            }
        }

        public int ExecuteScalar(string spName, SqlCommand cmd) {
            return ExecuteScalar(spName, cmd, CommandType.StoredProcedure);
        }

        public int ExecuteScalar(string sqlText) {
            return ExecuteScalar(sqlText, null, CommandType.Text);
        }

        #endregion

        #region ExecuteNonQuery
        public void ExecuteNonQuery(string sql, SqlCommand cmd, CommandType commandType) {
            SqlConnection cnn = new SqlConnection(GetConnectionString());
            try {
                if (cmd == null) {
                    cmd = new SqlCommand();
                }
                cmd.Connection = cnn;
                cmd.CommandText = sql;
                cmd.CommandType = commandType;
                cnn.Open();
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            } catch (Exception ex) {
                throw ex;
            } finally {
                cnn.Close();
            }
        }

        public void ExecuteNonQuery(string spName, SqlCommand cmd) {
            ExecuteNonQuery(spName, cmd, CommandType.StoredProcedure);
        }

        public void ExecuteNonQuery(string sqlText) {
            ExecuteNonQuery(sqlText, null, CommandType.Text);
        }
        #endregion

        #region ExecuteDataSet
        public DataSet ExecuteDataSet(string sql, SqlCommand cmd, CommandType commandType) {
            try {
                if (cmd == null) {
                    cmd = new SqlCommand();
                }
                SqlConnection cnn = new SqlConnection(GetConnectionString());
                cmd.Connection = cnn;
                cmd.CommandText = sql;
                cmd.CommandType = commandType;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Parameters.Clear();
                return ds;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public DataSet ExecuteDataSet(string spName, SqlCommand cmd) {
            return ExecuteDataSet(spName, cmd, CommandType.StoredProcedure);
        }

        public DataSet ExecuteDataSet(string sqlText) {
            return ExecuteDataSet(sqlText, null, CommandType.Text);
        }

        #endregion
    }
}
