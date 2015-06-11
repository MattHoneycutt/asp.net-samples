using System.Data.Entity;
using QueryEncapsulation.Web.Data;

namespace QueryEncapsulation.Web
{
	public static class EFConfig
	{
		public static void Initialize()
		{
			Database.SetInitializer(new DropCreateDatabaseAlways<AppDbContext>());
		}		 
	}
}