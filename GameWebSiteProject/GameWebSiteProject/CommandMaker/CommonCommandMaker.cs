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
        public static void AddParameter(string column, string value, SqlCommand command)
        {
            command.Parameters.Add(new SqlParameter($"@{column}", value));
        }
        public static string WhereConditionCreate(string column)
        {
            var where = new StringBuilder();
            where.Append($"WHERE \"{column}\" = @{column}");       
            return where.ToString();
        }
    }
}
