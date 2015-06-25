using System;
using StructureMap;
using StructureMapDecorator.Sample.Domain;
using StructureMapDecorator.Sample.Repositories;
using StructureMapDecorator.Sample.Services;

namespace StructureMapDecorator.Sample
{
	class Program
	{
		static void Main(string[] args)
		{
			User currentUser = GetCurrentUser();

			var container = new Container(cfg =>
			                              	{
			                              		cfg.For<User>().Use(currentUser);
			                              		cfg.For<IProductRepository>().Use<InMemoryProductRepository>();
												cfg.For<IProductRepository>().DecorateAllWith<ProductSecurityDecorator>();
												cfg.For<IProductRepository>().DecorateAllWith<ProductRepoLogger>();
												cfg.For<IProductRepository>().DecorateAllWith<RudeProductRepoLogger>();
			                              		cfg.For<IProductAuthorizer>().Use<ProductAuthorizer>();
			                              	});

			var repo = container.GetInstance<IProductRepository>();

			var product = repo.Find(1);

			Console.WriteLine(product);
		}

		private static User GetCurrentUser()
		{
			return new User {UserName = "Admin"};
		}
	}
}
