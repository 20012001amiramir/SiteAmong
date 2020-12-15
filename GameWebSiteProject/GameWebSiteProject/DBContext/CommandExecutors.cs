using System.Collections.Generic;
using System.Data.SqlClient;

namespace GameWebSiteProject.DBContext
{
    public abstract class CommandExecutors<T> where T : class
    {
        public virtual T PopulateRecord(SqlDataReader reader)
        {
            return null;
        }
        public void ExecuteNonQuery(SqlConnection connection, SqlCommand command)
        {
            command.Connection = connection;
            connection.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }
        public T GetRecord(SqlConnection connection, SqlCommand command)
        {
            T record = null;
            command.Connection = connection;
            connection.Open();
            try
            {
                var reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        record = PopulateRecord(reader);
                        break;
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            finally
            {
                connection.Close();
            }
            return record;
        }
        public ICollection<T> GetRecords(SqlConnection connection, SqlCommand command)
        {
            var list = new List<T>();
            command.Connection = connection;
            connection.Open();
            try
            {
                var reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                        list.Add(PopulateRecord(reader));
                }
                finally
                {
                    reader.Close();
                }
            }
            finally
            {
                connection.Close();
            }
            return list;
        }
    }
}
