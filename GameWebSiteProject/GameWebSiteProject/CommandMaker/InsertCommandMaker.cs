using System;
using System.Data.SqlClient;
using System.Text;

namespace GameWebSiteProject.CommandMaker
{
    public static class InsertCommandMaker<T> where T:class
    {
        public static SqlCommand Create(T obj)
        {
            SqlCommand result = new SqlCommand();
            result.CommandText = CreateCommandText(obj);
            CommonCommandMaker<T>.AddParameters(obj, result);         
            return result;
        }
        private static string CreateCommandText(T obj)
        {
            StringBuilder commandText = new StringBuilder();
            var tableName = '\"' + obj.GetType().Name + '\"';
            var columns = CreateValuesString(obj).Replace("@", String.Empty);
            var values = CreateValuesString(obj).Replace("\"", String.Empty);
            commandText.Append($"INSERT INTO {tableName} ({columns}) VALUES({values})");
            return commandText.ToString();
        }
        private static string CreateValuesString(T obj)
        {
            var columns = new StringBuilder();
            var properties = obj.GetType().GetProperties();
            for(int i=0; i < properties.Length-1; i++)
            {
                columns.Append('\"' + "@" + properties[i].Name + '\"' + ", ");
            }
            columns.Append('\"' + "@" + properties[properties.Length - 1].Name + '\"');
            return columns.ToString();
        }       
    }
}
