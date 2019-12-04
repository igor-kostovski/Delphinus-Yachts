using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using AutoMapper;

namespace Delphinus_Yachts.App_Start
{
    public class AutofacConfig
    {
        public static IContainer Initialize()
        {
            var builder = new ContainerBuilder();
            var assembly = Assembly.GetExecutingAssembly();

            var automapperProfiles = GetAllAutoMapperProfiles();

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                foreach (var profile in automapperProfiles)
                {
                    cfg.AddProfile(profile);
                }
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();

            builder.RegisterApiControllers(assembly);
            builder.RegisterControllers(assembly);

            builder.RegisterModule(new Delphinus_Yachts.Domain.IoCModule());

            var container = builder.Build();
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return container;
        }

        private static List<Profile> GetAllAutoMapperProfiles()
        {
            return Combine(Automapper.AutomapperWebConfig.GetProfiles(),
                Delphinus_Yachts.Domain.Automapper.AutomapperDomainConfig.GetProfiles());
        }

        private static List<Profile> Combine(params IEnumerable<Profile>[] lists)
        {
            return lists.SelectMany(x => x).ToList();
        }
    }
}