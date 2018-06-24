using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Welo.IoC;

namespace Welo.WebApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterDependencies();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<WebApplicationModule>();
            builder.RegisterModule<DataModule>();
            builder.RegisterModule<DomainModule>();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
