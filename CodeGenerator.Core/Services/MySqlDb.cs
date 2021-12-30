using CodeGenerator.Core.Models;
using MDbContext;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace CodeGenerator.Core.Services
{
    public class MySqlDb : DbOperatorBase, IDbOperator
    {
        private readonly string database;

        public MySqlDb(string connStr) : base(connStr)
        {
            var match = Regex.Match(connStr, @"(?<=Database\=)([A-Z|a-z]+)", RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                throw new Exception("未能在连接字符串中发现目标数据库!");
            }
            database = match.Value;
        }
        public Task<IEnumerable<DatabaseTable>> GetTablesAsync()
        {
            var sql = @$"SELECT
                                A.TABLE_NAME TableName
                                FROM INFORMATION_SCHEMA.TABLES A
                                WHERE a.TABLE_SCHEMA = '{database}'";
            return Db.QueryAsync<DatabaseTable>(sql, null);
        }

        public Task<IEnumerable<TableColumn>> GetTableStructAsync(string table)
        {
            string sql = $@"SELECT
                A.COLUMN_NAME ColumnName,
                A.DATA_TYPE DataType,
                A.IS_Nullable Nullable,
                A.COLUMN_COMMENT Comments
            FROM INFORMATION_SCHEMA.COLUMNS A
            WHERE A.TABLE_SCHEMA='{database}'
            AND A.TABLE_NAME = '{table}'
            ORDER BY A.TABLE_SCHEMA,A.TABLE_NAME,A.ORDINAL_POSITION";
            return Db.QueryAsync<TableColumn>(sql, null);
        }

        protected override DbContext CreateDbContext()
        {
            MySqlConnection conn = new(ConnectionString);
            DbContext.Init(DbBaseType.MySql);
            return conn.DbContext();
        }
    }
    //    public List<CommonItem<string>> GetTables()
    //    {
    //        var sql = @$"SELECT
    //    A.TABLE_NAME 
    //FROM INFORMATION_SCHEMA.TABLES A
    //where a.TABLE_SCHEMA = '{database}'";
    //        var dt = dBService.GetDataTable(sql);
    //        return dt.ToCommonList("TABLE_NAME", "TABLE_NAME");
    //    }

    //    public List<TableColumn> GetTableStruct(string table)
    //    {
    //        string sql = $@"SELECT
    //    A.COLUMN_NAME ColumnName,
    //    A.DATA_TYPE DataType,
    //    A.IS_Nullable Nullable,
    //    A.COLUMN_COMMENT Comments
    //FROM INFORMATION_SCHEMA.COLUMNS A
    //WHERE A.TABLE_SCHEMA='{database}'
    //AND A.TABLE_NAME = '{table}'
    //ORDER BY A.TABLE_SCHEMA,A.TABLE_NAME,A.ORDINAL_POSITION";
    //        return dBService.GetDataTable(sql).ToList();
    //    }
}
