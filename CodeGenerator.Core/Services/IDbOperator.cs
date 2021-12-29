using CodeGenerator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Core.Services
{
    public interface IDbOperator
    {
        Task<IEnumerable<DatabaseTable>> GetTablesAsync();
        Task<IEnumerable<TableColumn>> GetTableStructAsync();
    }
}
