using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GameWebSiteProject.Repository
{
    public abstract class AdoRepository<T> where T : class
    {
        private static SqlConnection connection;
        private static IConfiguration Configuration;
        public AdoRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            connection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection"));
        }
        protected void ExecuteNonQuery(SqlCommand command)
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
        public virtual T PopulateRecord(SqlDataReader reader)
        {
            return null;
        }
        protected IEnumerable<T> GetRecords(SqlCommand command)
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
        protected T GetRecord(SqlCommand command)
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
    }
}
