using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using ModelLib;

namespace MusicRest.DBUtil
{
    public class RecordManager
    {

        #region sql statements

        private const string GetAll = "select * from RecordsPairProgramming order by Title";
        private const string GetOneByTitle = "select * from RecordsPairProgramming where Title like @Title order by Title";
        private const string DeleteByTitle = "delete from RecordsPairProgramming where Title = @Title";

        #endregion


        public List<Record> Get()
        {
            List<Record> tempRecords = new List<Record>();

            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(GetAll, connection);

            SqlDataReader sqlReader = command.ExecuteReader();

            while (sqlReader.Read())
            {
                Record record = ReadRecord(sqlReader);
                tempRecords.Add(record);
            }

            connection.Close();

            return tempRecords;
        }

        public List<Record> GetByTitle(string title)
        {

            List<Record> tempRecords = new List<Record>();

            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(GetOneByTitle, connection);

            command.Parameters.AddWithValue("@Title", "%" + title + "%");

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Record recordToAdd = ReadRecord(reader);
                tempRecords.Add(recordToAdd);
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

            return tempRecord;
        }

        //public bool Delete(string title)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
        //    using(SqlCommand cmd = new SqlCommand(DeleteByTitle, connection)
        //    {
                
        //    }
        }
    }
}
