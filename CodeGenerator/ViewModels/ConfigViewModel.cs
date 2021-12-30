using CodeGenerator.Core;
using CodeGenerator.Core.Models;
using MT.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.ViewModels
{
    internal class ConfigViewModel : ViewModelBase, IDialogActivity
    {
        private Config _Config;
        public Config Config
        {
            get { return _Config; }
            set { SetValue(ref _Config, value); }
        }

        public object GetDialogResult()
        {
            return Config;
        }

        public void OnDialogClosing(IDialogParameter parameter)
        {

        }

        public void OnDialogOpening(IDialogParameter parameter)
        {
            Config = parameter.GetValue<Config>();
            if (Config == null)
            {
                Config = new();
                Config.Groups = new System.Collections.ObjectModel.ObservableCollection<Core.Template.ClassTemplate>()
                {
                    new()
                    {
                Name = "IRepository",
                SavePath = @"E:\GenerateCode\IRepository",
                FileNameTemplate = "I${TableNameFormatted}Repository.cs",
                Template = @"
using Project.Models.Entities;
namespace Project.IRepositories
{
    public interface I${TableNameFormatted}Repository : IRepositoryBase<${TableNameFormatted}>
    {

    }
}
"
                    },
                    new()
                    {
                Name = "Repository",
                SavePath = @"E:\GenerateCode\Repository",
                FileNameTemplate = "${TableNameFormatted}Repository.cs",
                Template = @"
using Project.IRepositories;
using Project.Models.Entities;
namespace Project.Repositories
{
    public class ${TableNameFormatted}Repository : RepositoryBase<${TableNameFormatted}>, I${TableNameFormatted}Repository
    {

    }
}
",
                    },
                    new()
                    {
                Name = "Model",
                SavePath = @"E:\GenerateCode\Model",
                HasContent = true,
                FileNameTemplate = "${TableNameFormatted}.cs",
                Template = @"
namespace Hello
{
    /// <summary>
    /// 
    /// </summary>
    [TableName(""${TableName}"")]
    public class ${TableNameFormatted}
    {
        ${Content}
    }
}
",
                    }
                };
            }
        }
    }
}
