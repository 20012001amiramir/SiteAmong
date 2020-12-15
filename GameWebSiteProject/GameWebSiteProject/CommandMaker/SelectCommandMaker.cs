using System;
using System.Data.SqlClient;
using System.Text;

namespace GameWebSiteProject.CommandMaker
{
    public class SelectCommandMaker<T> where T : class
    {
        public static SqlCommand Create(Type type)
        {
            SqlCommand result = new SqlCommand();
            result.CommandText = CreateCommandText(type);
            return result;
        }
        private static string CreateCommandText(Type type)
        {
            StringBuilder commandText = new StringBuilder();
            var tableName = '\"' + type.Name + '\"';
            commandText.Append($"SELECT * FROM {tableName}");
            return commandText.ToString();
        }
    }
}
