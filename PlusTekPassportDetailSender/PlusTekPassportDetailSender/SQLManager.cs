using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusTekPassportDetailSender
{
    class SQLManager
    {
        private string sqlConnectionStr;

        public Exception error = null;
        public List<OleDbParameter> paramArray = new List<OleDbParameter>();

        public SQLManager(string dbLocation)
        {
            if(TestConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + dbLocation + ";Persist Security Info = False;"))
            {
                sqlConnectionStr = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + dbLocation + ";Persist Security Info = False;";
            }
            else
            {
                throw new Exception("Connection error. Cannnot connect to result file!");
            }
        }

        public bool TestConnection(string ConnectionStr)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(ConnectionStr))
                {
                    conn.Open(); 
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        public DataTable ExecQuery(string Query)
        {

            DataTable dt = new DataTable();
            OleDbConnection con = new OleDbConnection(sqlConnectionStr);
            // Console.WriteLine(Query);
            try
            {
                error = null;
                con.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = Query;
                if (paramArray.Count > 0)
                    foreach (OleDbParameter p in paramArray)
                        cmd.Parameters.Add(p);
                OleDbDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);
                rdr.Close();
            }
            catch (Exception ex)
            {
                if (!String.IsNullOrEmpty(ex.Message))
                {
                    error = ex;
                    Console.WriteLine(error.Message);
                }

            }
            finally
            {

                con.Close();
            }

            return dt;

        }
        public void AddParam(string name, object value)
        {
            OleDbParameter param = new OleDbParameter(name, value);
            paramArray.Add(param);
        }
    }
}
