namespace QueryEncapsulation.Web.Data
{
	public static class QueryExtension
	{
		public static TQuery Query<TQuery>(this AppDbContext context)
			where TQuery : IQuery, new()
		{
			var query = new TQuery();
			query.Context = context;
			return query;
		}
	}
}