namespace QueryEncapsulation.Web.Data
{
	public interface IQuery
	{
		AppDbContext Context { get; set; }
	}
}