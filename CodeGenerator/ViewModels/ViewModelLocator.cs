using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.ViewModels
{
    internal class ViewModelLocator
    {
        public MainViewModel MainViewModel => new MainViewModel();
        public ConfigViewModel ConfigViewModel => new ConfigViewModel();
    }
}
