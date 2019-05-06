using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NewsServerMVC.Data
{
    public class DataAccess
    {
        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection connection = new SqlConnection("Data Source=DESKTOP-7VUR12S\\GUER;" + "Initial Catalog=NewsDB;" + "Integrated Security=SSPI;"))
            {
                return connection.Query<T>(sql).ToList();
            }
        }
        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection connection = new SqlConnection("Data Source=DESKTOP-7VUR12S\\GUER;" + "Initial Catalog=NewsDB;" + "Integrated Security=SSPI;"))
            {
                    return connection.Execute(sql, data);                
            }
        }
    }
}
