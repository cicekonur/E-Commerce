using Core.DataAccess;
using Core.DataAccess.SqlServer.EntityFramework;
using ETicaret.BLL.Abstracts;
using ETicaret.Dal;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.BLL.IOC.Module
{
    public class BLLModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IUrunService>().To<UrunService>();
            Bind<IKategoriService>().To<KategoriService>();
            Bind<ILoginService>().To<LoginService>();
            

            List<INinjectModule> modules = new List<INinjectModule>();
            modules.Add(new DalModule());
            Kernel.Load(modules);
        }
    }
}
