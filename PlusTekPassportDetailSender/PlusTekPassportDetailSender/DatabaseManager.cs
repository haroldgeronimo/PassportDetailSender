using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
namespace PlusTekPassportDetailSender
{
    class DatabaseManager
    {
        public SQLManager sqlManager;
        public DatabaseManager()
        {
            try
            {
                sqlManager = new SQLManager(SaveData.dbLocation);
            }
            catch (Exception e)
            {
                throw e;

            }
        }

        public DataTable SelectAll(string tableName)
        {
            return sqlManager.ExecQuery("SELECT * FROM " + tableName);
        }
        public DataTable Select(int id, string idColumn, string tableName)
        {
            return sqlManager.ExecQuery($"SELECT * FROM {tableName} WHERE {idColumn} = {id}");

        }

        public DataTable SelectLast(string column, string tableName)
        {
            return sqlManager.ExecQuery($"SELECT TOP 1 * FROM {tableName} Order by {column} desc");

        }
    }
}