using System.Data.Entity;
using QueryEncapsulation.Web.Domain;

namespace QueryEncapsulation.Web.Data
{
	public class AppDbContext : DbContext
	{
		public IDbSet<Post> Posts { get; set; }
	}
}