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

        private string _getAll = "select * from RecordsPairProgramming order by Title";


        #endregion


        public List<Record> Get()
        {
            List<Record> tempRecords = new List<Record>();

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(_getAll, connection);

            SqlDataReader sqlReader = command.ExecuteReader();

            while (sqlReader.Read())
            {
                Record record = ReadRecord(sqlReader);
                tempRecords.Add(record);
            }

            connection.Close();

            return tempRecords;
        }

        private Record ReadRecord(SqlDataReader reader)
        {
            Record tempRecord = new Record();

            tempRecord.Title = reader.GetString(0);
            tempRecord.Artist = reader.GetString(1);
            tempRecord.Duration = reader.GetDouble(2);
            tempRecord.YearOfPublication = reader.GetInt32(3);
            tempRecord.Album = reader.GetString(4);

            return tempRecord;
        }
    }
}
