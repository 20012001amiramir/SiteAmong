using System.Data.SqlClient;
using System.Text;

namespace GameWebSiteProject.CommandMaker
{
    public class UpdateWhereCommandMaker<T> where T : class
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
            var columns = CreateValuesString(obj);
            string[] columnValues ={ "Id" };
            var where = CommonCommandMaker<T>.WhereConditionCreate(columnValues);            
            commandText.Append($"UPDATE {tableName} SET {columns} {where}");
            return commandText.ToString();
        }
        private static string CreateValuesString(T obj)
        {
            var columns = new StringBuilder();
            var properties = obj.GetType().GetProperties();
            for (int i = 0; i < properties.Length - 1; i++)
            {
                columns.Append('\"' + properties[i].Name + '\"' + " = " + "@" + properties[i].Name + ", ");
            }
            columns.Append('\"' + properties[properties.Length - 1].Name + '\"' + " = " + "@" + properties[properties.Length - 1].Name);
            return columns.ToString();
        }
    }
}
