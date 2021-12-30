using CodeGenerator.Core;
using CodeGenerator.Core.Enums;
using CodeGenerator.Core.Models;
using CodeGenerator.Core.Services;
using CodeGenerator.Core.Template;
using MT.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.IO;
using CodeGenerator.Core.Helper;

namespace CodeGenerator.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private IDbOperator _dbOperator;
        private string _ConnectionString = "Data Source=172.18.180.41;Database=videocollection;User ID=videocollection;Password=hgbanner;charset=gbk";
        public string ConnectionString
        {
            get { return _ConnectionString; }
            set { SetValue(ref _ConnectionString, value); }
        }

        private ObservableCollection<DatabaseTable> _TableList = new();
        public ObservableCollection<DatabaseTable> TableList
        {
            get { return _TableList; }
            set { SetValue(ref _TableList, value); }
        }

        public DatabaseType SelectedType { get; set; }
        public List<SelectionItem<DatabaseType>> DataBaseList { get; set; }

        private StringBuilder _Temp = new StringBuilder();
        public string Temp => _Temp.ToString();

        private Config _Config;
        public Config Config
        {
            get { return _Config; }
            set
            {
                SetValue(ref _Config, value);
                ShowTemp();
            }
        }


        public MainViewModel()
        {
            DataBaseList = new List<SelectionItem<DatabaseType>>();
            DataBaseList.Add(new SelectionItem<DatabaseType> { Display = "Oracle", Value = DatabaseType.Oracle });
            DataBaseList.Add(new SelectionItem<DatabaseType> { Display = "SqlServer", Value = DatabaseType.SqlServer });
            DataBaseList.Add(new SelectionItem<DatabaseType> { Display = "MySql", Value = DatabaseType.MySql });

            Config = ConfigHelper.ReadConfig();
        }
        private void ShowTemp()
        {
            if (Config == null)
                return;
            _Temp.Clear();
            foreach (var item in Config.Groups)
            {
                _Temp.AppendLine($"======================{item.Name}=====================");
                _Temp.AppendLine();
                _Temp.AppendLine(item.Template);
                _Temp.AppendLine();
            }
            RaisePropertyChanged(nameof(Temp));
        }


        public RelayCommand ConnectCommand => new(async () =>
        {
            _dbOperator = DbFactory.GetDbOperator(SelectedType, ConnectionString);
            var tables = await _dbOperator.GetTablesAsync();
            TableList = new(tables);
        });

        public RelayCommand ConfigCommand => new(async () =>
        {
            var result = await DialogService.Show<ConfigViewModel>("模板配置", p: Config);
            if (result.DialogAction == DialogFeedback.Confirm)
            {
                Config = ((Config)result.Result);
                await ConfigHelper.SaveConfig(Config);
            }
        });
        public RelayCommand BuildCommand => new(async () =>
        {
            var selected = TableList.Where(t => t.IsSelected);
            if (!selected.Any())
            {
                RemindBox.Error("未选择表!");
                return;
            }
            foreach (var item in selected)
            {
                item.Columns = await _dbOperator.GetTableStructAsync(item.TableName);
            }
            var prefix = Config.Prefix ?? "";
            var separator = Config.Separator ?? "";
            foreach (var table in selected)
            {
                foreach (var item in Config.Groups)
                {
                    string formatted = table.PascalName(prefix, separator);
                    var temp = item.Template.Replace("${TableName}", table.TableName).Replace("${TableNameFormatted}", formatted);
                    if (item.HasContent)
                    {
                        string content = table.BuildContent(prefix, separator);
                        temp = temp.Replace("${Content}", content);
                    }
                    await item.SaveFile(item.FileNameTemplate.Replace("${TableNameFormatted}", formatted), temp);
                }
            }            
        });
    }

}
