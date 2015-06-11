using System;
using System.Linq;
using QueryEncapsulation.Web.Domain;

namespace QueryEncapsulation.Web.Data
{
	public static class PostQueryExtensions
	{
		public static IQueryable<Post> TopPostsForDateRangeWithMSContributors(
			this IQueryable<Post> posts, DateTime startDate, DateTime endDate)
		{
			return posts.Where(x => x.PostDate >= startDate && x.PostDate < endDate &&
			                        x.Comments.Count() >= 3 && 
			                        x.Comments.Any(c => c.Email.Contains("@microsoft")));
		}

		public static IQueryable<Post> Between(this IQueryable<Post> posts, DateTime startDate, DateTime endDate)
		{
			return posts.Where(x => x.PostDate >= startDate && x.PostDate < endDate);
		}

		public static IQueryable<Post> WithAtLeastXComments(this IQueryable<Post> posts, int commentCount)
		{
			return posts.Where(x => x.Comments.Count() >= commentCount);
		}

		public static IQueryable<Post> WithMicrosoftCommenters(this IQueryable<Post> posts)
		{
			return posts.Where(x => x.Comments.Any(c => c.Email.Contains("@microsoft")));
		}
	}
}