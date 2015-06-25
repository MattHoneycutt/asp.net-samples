using System;
using StructureMapDecorator.Sample.Domain;

namespace StructureMapDecorator.Sample.Repositories
{
	public class RudeProductRepoLogger : IProductRepository
	{
		private readonly IProductRepository _target;

		public RudeProductRepoLogger(IProductRepository target)
		{
			_target = target;
		}

		public Product Find(int id)
		{
			Console.WriteLine("Hey there, jerk.");

			return _target.Find(id);
		}
	}
}