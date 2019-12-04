using System.Reflection;
using System.Web;
using Autofac;
using Delphinus_Yachts.Domain.Data;
using Delphinus_Yachts.Domain.Data.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Module = Autofac.Module;

namespace Delphinus_Yachts.Domain
{
    public class IoCModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).Where(x => x.Name.EndsWith("Service")).AsSelf();
            builder.RegisterType<DataContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<AppUserManager>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<AppSignInManager>().AsSelf().InstancePerLifetimeScope();
            builder.Register(x => new UserStore<User>(x.Resolve<DataContext>())).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.Register(x => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>();
            builder.Register(x => new IdentityFactoryOptions<AppUserManager>
            {
                DataProtectionProvider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("Delphinus_Yachts")
            });

            base.Load(builder);
        }
    }
}
