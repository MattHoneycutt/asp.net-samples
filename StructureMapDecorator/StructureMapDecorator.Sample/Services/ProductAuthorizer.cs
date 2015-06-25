using StructureMapDecorator.Sample.Domain;

namespace StructureMapDecorator.Sample.Services
{
	public class ProductAuthorizer : IProductAuthorizer
	{
		public bool IsUserAuthorizedToAccessProduct(User user, int productID)
		{
			if (user.UserName == "Admin")
			{
				return true;
			}
			else
			{
				return false;	
			}
		}
	}
}