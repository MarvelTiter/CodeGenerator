using System.Data;

namespace CodeGenerator.Core.Models
{
    public class TableColumn
    {
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public string Nullable { get; set; }
        public string Comments { get; set; }
    }
}
