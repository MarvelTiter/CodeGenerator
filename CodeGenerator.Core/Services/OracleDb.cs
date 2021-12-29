using CodeGenerator.Core.Models;
using MDbContext;

namespace CodeGenerator.Core.Services
{
    public class OracleDb : DbOperatorBase, IDbOperator
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
    //public List<CommonItem<string>> GetTables()
    //{
    //    string sql = "select table_name from user_tab_columns group by table_name order by table_name";
    //    var dt = dBService.GetDataTable(sql);
    //    var ret = dt.ToCommonList("table_name", "table_name");
    //    return ret;
    //}

    //public List<TableColumn> GetTableStruct(string table)
    //{
    //    StringBuilder sql = new StringBuilder();
    //    sql.AppendLine(" SELECT b.comments as Comments, ");
    //    sql.AppendLine(" a.column_name as ColumnName, ");
    //    sql.AppendLine(" a.data_type || '(' || a.data_length || ')' as DataType, ");
    //    sql.AppendLine(" a.nullable as Nullable");
    //    sql.AppendLine(" FROM user_tab_columns a, user_col_comments b");
    //    sql.AppendLine($" WHERE a.TABLE_NAME = '{table}'");
    //    sql.AppendLine($" and b.table_name = '{table}'");
    //    sql.AppendLine(" and a.column_name = b.column_name");
    //    var dt = dBService.GetDataTable(sql.ToString());

    //    var list = dt.ToList();
    //    list.Reverse();
    //    return list;
    //}
}
