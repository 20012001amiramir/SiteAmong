using System.Data.SqlClient;
using System.Text;

namespace GameWebSiteProject.CommandMaker
{
    public static class CommonCommandMaker<T> where T:class
    {
        public static void AddParameters(T obj, SqlCommand command)
        {
            var properties = obj.GetType().GetProperties();
            foreach (var x in properties)
            {
                command.Parameters.Add(new SqlParameter($"@{x.Name}", x.GetValue(obj)));
            }
        }
        public static void AddParameters(string [] columns, string [] values, SqlCommand command)
        {
            for(int i = 0; i < columns.Length; i++)
            {
                command.Parameters.Add(new SqlParameter($"@{columns[i]}", values[i]));
            }
            
        }
        public static string WhereConditionCreate(string []columns)
        {
            var where = new StringBuilder();
            where.Append("WHERE ");
            for (int i = 0; i < columns.Length - 1; i++) 
            {
                where.Append($"\"{columns[i]}\" = @{columns[i]} AND ");
            }
            
            where.Append($"\"{columns[columns.Length - 1]}\" = @{columns[columns.Length - 1]}");
            
            
            return where.ToString();
        }

    }
}
