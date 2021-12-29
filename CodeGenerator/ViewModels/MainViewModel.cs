using CodeGenerator.Core.Enums;
using CodeGenerator.Core.Models;
using CodeGenerator.Core.Services;
using MT.Controls;
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
        public DatabaseType SelectedType { get; set; }
        public List<SelectionItem<DatabaseType>> DataBaseList { get; set; }

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

            DataBaseList = new List<SelectionItem<DatabaseType>>();
            DataBaseList.Add(new SelectionItem<DatabaseType> { Display = "Oracle", Value = DatabaseType.Oracle });
            DataBaseList.Add(new SelectionItem<DatabaseType> { Display = "SqlServer", Value = DatabaseType.SqlServer });
            DataBaseList.Add(new SelectionItem<DatabaseType> { Display = "MySql", Value = DatabaseType.MySql });
        }

        public RelayCommand ConnectCommand => new(async () =>
        {
            var @operator = DbFactory.GetDbOperator(SelectedType, ConnectionString);
            var tables = await @operator.GetTablesAsync();
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
            RemindBox.Success(dbt.TableName);
            ConnectionString = dbt.TableName;
        });

    }
}
