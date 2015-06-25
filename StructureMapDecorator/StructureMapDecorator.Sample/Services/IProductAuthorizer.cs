using StructureMapDecorator.Sample.Domain;

namespace StructureMapDecorator.Sample.Services
{
	public interface IProductAuthorizer
	{
		bool IsUserAuthorizedToAccessProduct(User user, int productID);
	}
}