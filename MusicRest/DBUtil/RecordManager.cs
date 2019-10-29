using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ModelLib;

namespace MusicRest.DBUtil
{
    public class RecordManager
    {

        #region ConnectionString

        private string _connectionString =
            "Data Source=ande-zealand-dbserver.database.windows.net;Initial Catalog=Ande-Zealand-DB;User ID=;Password=;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        #endregion

        #region sql statements

        private string _getAll = "select * from RecordsPairProgramming";


        #endregion


        public List<Record> Get()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(_getAll, connection);
            SqlDataReader sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
                Record record = readRecord(sqlReader);
            }

        }

        private Record readRecord()
        {

        }
    }
}
