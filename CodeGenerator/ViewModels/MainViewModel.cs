using CodeGenerator.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private string _ConnectionString;
        public string ConnectionString
        {
            get { return _ConnectionString; }
            set { SetValue(ref _ConnectionString, value); }
        }

        private ObservableCollection<DatabaseTable> _TableList;
        public ObservableCollection<DatabaseTable> TableList
        {
            get { return _TableList; }
            set { SetValue(ref _TableList, value); }
        }
        
        public MainViewModel()
        {
            TableList = new()
            {
                new()
                {
                    TableName = "table1",
                },
                new()
                {
                    TableName = "table2",
                }
            };
            ConnectionString = "连接字符串";
        }

        public RelayCommand ConnectCommand => new(() =>
        {
        });

        public RelayCommand ConfigCommand => new(() =>
        {
            TableList.Add(new()
            {
                TableName = "table123"
            });
        });

        public RelayCommand<DatabaseTable> SelectionChangedCommand => new(dbt =>
        {
            ConnectionString = dbt.TableName;
        });

    }
}
