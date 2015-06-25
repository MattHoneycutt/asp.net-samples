using StructureMapDecorator.Sample.Domain;

namespace StructureMapDecorator.Sample.Repositories
{
	public interface IProductRepository
	{
		Product Find(int id);
	}
}