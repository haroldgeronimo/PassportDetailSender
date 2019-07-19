using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusTekPassportDetailSender
{
    class PassportDetailReader
    {
        public static PassportDetailReader singleton;
        DatabaseManager dbm;
        string tableName = "Result";
        string idColumn = "Index";
        public PassportDetailReader()
        {
            singleton = this;
            dbm = new DatabaseManager();
        }    
        
        public Passport GetLast()
        {
            DataTable dt = dbm.SelectLast(idColumn, tableName);
            if (dt.Rows.Count == 0) return null;
            else { return new Passport(dt.Rows[0]); }
        }

        public int GetCount()
        {
            DataTable dt = dbm.SelectAll(tableName);
            return dt.Rows.Count;
        }
    }
}
