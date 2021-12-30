using MDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Core.Services
{
    public abstract class DbOperatorBase
    {
        protected readonly string ConnectionString;

        public DbOperatorBase(string connStr)
        {
            this.ConnectionString = connStr;
        }
        public DbContext Db => CreateDbContext();

        protected abstract DbContext CreateDbContext();

    }
}
