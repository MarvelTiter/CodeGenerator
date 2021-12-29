using CodeGenerator.Core.Models;
using MDbContext;

namespace CodeGenerator.Core.Services
{
    public class MySqlDb : DbOperatorBase, IDbOperator
    {
        public Task<IEnumerable<DatabaseTable>> GetTablesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TableColumn>> GetTableStructAsync()
        {
            throw new NotImplementedException();
        }

        protected override DbContext CreateDbContext()
        {
            throw new NotImplementedException();
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
