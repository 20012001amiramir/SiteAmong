using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWebSiteProject.CommandMaker
{
    public class DeleteWhereCommandMaker<T> where T : class
    {
        public static SqlCommand Create(string column, string value, Type type)
        {
            SqlCommand result = new SqlCommand();
            result.CommandText = CreateCommandText(column, type);
            CommonCommandMaker<T>.AddParameter(column, value, result);
            return result;
        }
        private static string CreateCommandText(string column, Type type)
        {
            StringBuilder commandText = new StringBuilder();
            var tableName = '\"' + type.Name + '\"';
            var where = CommonCommandMaker<T>.WhereConditionCreate(column);
            commandText.Append($"DELETE FROM {tableName} {where}");
            return commandText.ToString();
        }


    }
}
