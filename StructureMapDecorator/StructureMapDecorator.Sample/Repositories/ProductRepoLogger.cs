using System;
using StructureMapDecorator.Sample.Domain;

namespace StructureMapDecorator.Sample.Repositories
{
	public class ProductRepoLogger : IProductRepository
	{
		private readonly IProductRepository _target;
		private readonly User _user;

		public ProductRepoLogger(IProductRepository target, User user)
		{
			_target = target;
			_user = user;
		}

		public Product Find(int id)
		{
			Console.WriteLine("{0} is requesting product {1}.", _user, id);

			return _target.Find(id);
		}
	}
}