using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using GameWebSiteProject.CommandMaker;
using System;
using System.Reflection;

namespace GameWebSiteProject.DBContext
{
    internal class DbProvider<T>: CommandExecutors<T>, IDataSourceProvider<T> where T : class , new()
    {
        private static SqlConnection connection;
        public DbProvider(IConfiguration configuration)
        {
            connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public void Add(T obj)
        {
            using(SqlCommand command = InsertCommandMaker<T>.Create(obj))
            {
                ExecuteNonQuery(connection, command);
            }              
        }

        public T GetBy(string column, string value, Type type)
        {
            using (SqlCommand command = SelectWhereCommandMaker<T>.Create(column, value, type))
            {
                return GetRecord(connection, command);
            }
        }

        public void Update(T obj)
        {
            using (SqlCommand command = UpdateWhereCommandMaker<T>.Create(obj))
            {
                ExecuteNonQuery(connection, command);
            }
        }

        public IEnumerable<T> GetAll(Type type)
        {
            using (SqlCommand command = SelectCommandMaker<T>.Create(type))
            {
                return GetRecords(connection, command);
            }
        }

        public void DeleteWhere(string column, string value, Type type)
        {
            throw new System.NotImplementedException();
        }
          
        public override T PopulateRecord(SqlDataReader reader)
        {
            T record = new T();
            Type type = typeof(T);
            var properties = type.GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                var propertyType = properties[i].PropertyType;
                PropertyInfo prop = type.GetProperty($"{reader.GetName(i)}");
                var value = Convert.ChangeType(reader.GetValue(i), propertyType);
                prop.SetValue(record, value, null);              
            }
            return record;
        }
    }
}
