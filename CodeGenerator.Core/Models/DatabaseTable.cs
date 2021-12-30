using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Core.Models
{
    public class DatabaseTable : ObservableObject
    {
        public string TableName { get; set; }
        public IEnumerable<TableColumn> Columns { get; set; }

        private bool _IsSelected;
        public bool IsSelected
        {
            get { return _IsSelected; }
            set { SetValue(ref _IsSelected, value); }
        }
    }
}
