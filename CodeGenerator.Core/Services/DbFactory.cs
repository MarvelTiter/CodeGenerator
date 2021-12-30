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
                DatabaseType.Oracle => new OracleDb(connectionString),
                DatabaseType.SqlServer => new SqlServerDb(connectionString),
                DatabaseType.MySql => new MySqlDb(connectionString),
                _ => throw new NotSupportedException(),
            };
        }
    }
}
