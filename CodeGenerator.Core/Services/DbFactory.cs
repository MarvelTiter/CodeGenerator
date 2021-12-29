using CodeGenerator.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Core.Services
{
    public class DbFactory
    {
        public static IDbOperator GetDbOperator(DatabaseType databaseType, string connectionString)
        {
            return databaseType switch
            {
                DatabaseType.Oracle => new OracleDb(),
                DatabaseType.SqlServer => new SqlServerDb(),
                DatabaseType.MySql => new MySqlDb(),
                _ => throw new NotSupportedException(),
            };
        }
    }
}
