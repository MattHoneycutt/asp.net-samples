using System;
using System.Linq;
using AutoMapper.QueryableExtensions;
using QueryEncapsulation.Web.Models;

namespace QueryEncapsulation.Web.Data
{
	public class TopPostsQuery : IQuery
	{
		public AppDbContext Context { get; set; }

		public TopPostModel[] Execute(DateTime startDate, DateTime endDate)
		{
			return Context.Posts.Where(x =>
				x.PostDate >= startDate &&
				x.PostDate < endDate &&
				x.Comments.Count() >= 3 && 
				x.Comments.Any(c => c.Email.Contains("@microsoft")))
				.Project().To<TopPostModel>()
				.ToArray();
		}
	}
}