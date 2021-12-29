using System.Data;

namespace CodeGenerator.Core.Models
{
    public class TableColumn
    {
        public string Name { get; set; }
        public DbType DbType { get; set; }
    }
}
