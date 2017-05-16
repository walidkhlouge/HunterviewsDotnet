
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication;

namespace WebApplication.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
       HunterViewContext DataContext { get; }
    }

}
