using System.Security;
using StructureMapDecorator.Sample.Domain;
using StructureMapDecorator.Sample.Services;

namespace StructureMapDecorator.Sample.Repositories
{
	public class ProductSecurityDecorator : IProductRepository
	{
		private readonly IProductRepository _target;
		private readonly IProductAuthorizer _securityService;
		private readonly User _currentUser;

		public ProductSecurityDecorator(IProductRepository target, IProductAuthorizer securityService, User currentUser)
		{
			_target = target;
			_securityService = securityService;
			_currentUser = currentUser;
		}

		public Product Find(int id)
		{
			if (_securityService.IsUserAuthorizedToAccessProduct(_currentUser, id))
			{
				return _target.Find(id);
			}
			else
			{
				throw new SecurityException("You are not authorized to access this product!");
			} 
		}
	}
}