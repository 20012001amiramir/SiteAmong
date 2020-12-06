using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace GameWebSiteProject.CommandMaker
{
    public static class InsertCommandMaker
    {
        public static SqlCommand Create(object obj)
        {
            SqlCommand result = new SqlCommand();
            result.CommandText = CreateCommandText(obj);
            AddParameters(obj, result);         
            return result;
        }
        public static string CreateCommandText(object obj)
        {
            StringBuilder commandText = new StringBuilder();
            var tableName = '\"' + obj.GetType().Name + '\"';
            var columns = CreateValuesString(obj).Replace("@", String.Empty);
            var values = CreateValuesString(obj).Replace("\"", String.Empty);
            commandText.Append($"INSERT INTO {tableName} ({columns}) VALUES({values})");
            return commandText.ToString();
        }
        private static string CreateValuesString(object obj)
        {
            var columns = new StringBuilder();
            var fields = obj.GetType().GetProperties();
            for(int i=0; i < fields.Length-1; i++)
            {
                columns.Append('\"' + "@" + fields[i].Name + '\"' + ", ");
            }
            columns.Append('\"' + "@" + fields[fields.Length - 1].Name + '\"');
            return columns.ToString();
        }
        private static void AddParameters(object obj, SqlCommand command)
        {
            var properties = obj.GetType().GetProperties();
            List<SqlParameter> parameters = new List<SqlParameter>();
            foreach (var x in properties)
            {
                command.Parameters.Add(new SqlParameter($"@{x.Name}", x.GetValue(obj)));
            }
        }
        
    }
}
