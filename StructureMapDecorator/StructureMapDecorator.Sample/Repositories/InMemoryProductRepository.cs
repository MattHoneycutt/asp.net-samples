using StructureMapDecorator.Sample.Domain;

namespace StructureMapDecorator.Sample.Repositories
{
	public class InMemoryProductRepository : IProductRepository
	{
		public Product Find(int id)
		{
			return new Product { ID = id };
		}
	}
}