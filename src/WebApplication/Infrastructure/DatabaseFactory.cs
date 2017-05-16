using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication;

namespace WebApplication.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private HunterViewContext dataContext;
        public HunterViewContext DataContext { get { return dataContext; } }

        public DatabaseFactory()
        {
            dataContext = new HunterViewContext();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }

}
