using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itc.Am.DL;
using Itc.Am.DL.Interfaces;

namespace Itc.Am.DL.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        StoreEntities _dbContext;

        public StoreEntities Init()
        {
            return _dbContext ?? (_dbContext = new StoreEntities());
        }

        protected override void DisposeCore()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
        }
    }
}
