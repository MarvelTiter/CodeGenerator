using CodeGenerator.Core.Template;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Core.Models
{
    public class Config:ObservableObject
    {
        private string _Prefix;
        public string Prefix
        {
            get { return _Prefix; }
            set { SetValue(ref _Prefix, value); }
        }
        private string _Separator;
        public string Separator
        {
            get { return _Separator; }
            set { SetValue(ref _Separator, value); }
        }
        private ObservableCollection<ClassTemplate> _Groups;
        public ObservableCollection<ClassTemplate> Groups
        {
            get { return _Groups; }
            set { SetValue(ref _Groups, value); }
        }

    }
}
