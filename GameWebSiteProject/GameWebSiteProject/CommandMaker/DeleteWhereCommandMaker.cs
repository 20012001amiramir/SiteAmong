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
        public static SqlCommand Create(Type type, params string[] columnValue)
        {
            string[] columns = new string[columnValue.Length / 2];
            string[] values = new string[columnValue.Length / 2];
            int j = 0;
            for (int i = 0; i < columnValue.Length; i = i + 2)
            {
                columns[j] = columnValue[i];
                if (columnValue[i + 1] == null)
                {
                    values[j] = "";
                }
                else
                {
                    values[j] = columnValue[i + 1];
                }             
                j++;
            }

            SqlCommand result = new SqlCommand();
            result.CommandText = CreateCommandText(columns, type);
            CommonCommandMaker<T>.AddParameters(columns, values, result);
            return result;
        }
        private static string CreateCommandText(string [] columns, Type type)
        {
            StringBuilder commandText = new StringBuilder();
            var tableName = '\"' + type.Name + '\"';
            var where = CommonCommandMaker<T>.WhereConditionCreate(columns);
            commandText.Append($"DELETE FROM {tableName} {where}");
            return commandText.ToString();
        }


    }
}
