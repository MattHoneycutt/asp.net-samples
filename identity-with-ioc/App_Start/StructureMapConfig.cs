using System.Data.Entity;
using System.Web;
using Heroic.Web.IoC;
using System.Web.Http;
using System.Web.Mvc;
using identity_with_ioc.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using StructureMap;
using StructureMap.Graph;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(identity_with_ioc.StructureMapConfig), "Configure")]
namespace identity_with_ioc
{
	public static class StructureMapConfig
	{
		public static void Configure()
		{
			ObjectFactory.Configure(cfg =>
			{
				cfg.Scan(scan =>
				{
					scan.TheCallingAssembly();
					scan.WithDefaultConventions();
				});

				cfg.AddRegistry(new ControllerRegistry());
				cfg.AddRegistry(new MvcRegistry());
				cfg.AddRegistry(new ActionFilterRegistry(namespacePrefix: "identity_with_ioc"));

				//TODO: Add other registries and configure your container!
				cfg.For<ApplicationSignInManager>().Use(ctx =>
					ctx.GetInstance<HttpContextBase>().GetOwinContext().Get<ApplicationSignInManager>());
				cfg.For<ApplicationUserManager>().Use(ctx =>
					ctx.GetInstance<HttpContextBase>().GetOwinContext().GetUserManager<ApplicationUserManager>());
			});

			var resolver = new StructureMapDependencyResolver();
			DependencyResolver.SetResolver(resolver);
			GlobalConfiguration.Configuration.DependencyResolver = resolver;
		}
	}
}