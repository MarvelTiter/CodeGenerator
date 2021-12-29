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
        public DbContext Db => CreateDbContext();

        protected abstract DbContext CreateDbContext();

    }
}
