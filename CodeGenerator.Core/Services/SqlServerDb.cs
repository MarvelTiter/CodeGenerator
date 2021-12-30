using CodeGenerator.Core.Models;
using MDbContext;

namespace CodeGenerator.Core.Services
{
    public class SqlServerDb : DbOperatorBase, IDbOperator
    {
        public SqlServerDb(string connStr):base(connStr)
        {

        }
        public Task<IEnumerable<DatabaseTable>> GetTablesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TableColumn>> GetTableStructAsync(string table)
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
    //    string sql = "SELECT NAME FROM SYSOBJECTS WHERE XTYPE = 'U' ORDER BY NAME";
    //    var dt = dBService.GetDataTable(sql);
    //    var ret = dt.ToCommonList("NAME", "NAME");
    //    return ret;
    //}

    //public List<TableColumn> GetTableStruct(string table)
    //{
    //    StringBuilder sql = new StringBuilder();
    //    sql.AppendLine(" SELECT ");
    //    sql.AppendLine(" --表名 =case when a.colorder = 1 then d.name else '' end, ");
    //    sql.AppendLine(" --表说明 =case when a.colorder = 1 then isnull(f.value,'') else '' end, ");
    //    sql.AppendLine(" --字段序号 = a.colorder, ");
    //    sql.AppendLine(" ColumnName = a.name, ");
    //    sql.AppendLine(" --标识 =case when COLUMNPROPERTY(a.id, a.name,'IsIdentity')= 1 then '√'else '' end, ");
    //    sql.AppendLine(" --主键 =case when exists(SELECT 1 FROM sysobjects where xtype = 'PK' and name in ( ");
    //    sql.AppendLine(" --SELECT name FROM sysindexes WHERE indid in( ");
    //    sql.AppendLine(" --SELECT indid FROM sysindexkeys WHERE id = a.id AND colid = a.colid ");
    //    sql.AppendLine(" --  ))) then '√' else '' end, ");
    //    sql.AppendLine(" DataType = b.name, ");
    //    sql.AppendLine(" --占用字节数 = a.length, ");
    //    sql.AppendLine(" --长度 = COLUMNPROPERTY(a.id, a.name, 'PRECISION'), ");
    //    sql.AppendLine(" --小数位数 = isnull(COLUMNPROPERTY(a.id, a.name, 'Scale'), 0), ");
    //    sql.AppendLine(" Nullable =case when a.isnullable = 1 then '√'else '' end, ");
    //    sql.AppendLine(" --默认值 = isnull(e.text, ''), ");
    //    sql.AppendLine(" Comments = isnull(g.[value], '') ");
    //    sql.AppendLine(" FROM syscolumns a ");
    //    sql.AppendLine(" left join systypes b on a.xtype = b.xusertype ");
    //    sql.AppendLine(" inner join sysobjects d on a.id = d.id and d.xtype = 'U' and d.name <> 'dtproperties' ");
    //    sql.AppendLine(" left join syscomments e on a.cdefault = e.id ");
    //    sql.AppendLine(" left join sys.extended_properties g on a.id = g.major_id and a.colid = g.minor_id ");
    //    sql.AppendLine(" left join sys.extended_properties f on d.id = f.major_id and f.minor_id = 0 ");
    //    sql.AppendLine($" where d.name = '{table}'--如果只查询指定表,加上此条件 ");
    //    sql.AppendLine(" order by a.id,a.colorder ");
    //    var list = dBService.GetDataTable(sql.ToString()).ToList();
    //    return list;
    //}
}
