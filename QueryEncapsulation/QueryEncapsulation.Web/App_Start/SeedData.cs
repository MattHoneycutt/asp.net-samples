using System;
using System.Linq;
using QueryEncapsulation.Web.Data;
using QueryEncapsulation.Web.Domain;

namespace QueryEncapsulation.Web
{
	public static class SeedData
	{
		public static void Init()
		{
			using (var context = new AppDbContext())
			{
				if (!context.Posts.Any())
				{
					context.Posts.Add(new Post{PostDate=DateTime.Parse("6/1/2015"), Title = "New Tech Roundup", Body = "", Comments = {new Comment{Email = "zune@microsoft.com"}, new Comment{Email = "dart@google.com"}}});
					context.Posts.Add(new Post{PostDate=DateTime.Parse("6/2/2015"), Title = "Hipsters, and how to spot them", Body = "", Comments = {new Comment{Email = "clippy@microsoft.com"}, new Comment{Email = "polymer@google.com"}, new Comment{Email = "silverlight@microsoft.com"}}});
					context.Posts.Add(new Post{PostDate=DateTime.Parse("6/3/2015"), Title = "Bug or feature?", Body = "", Comments = {new Comment{Email = "vista@microsoft.com"}, new Comment{Email = "angularjs@google.com"}, new Comment{Email = "vs2015@microsoft.com"}}});
					context.Posts.Add(new Post{PostDate=DateTime.Parse("6/4/2015"), Title = "Hot Tech Features", Body = "", Comments = {new Comment{Email = "aurelia@awesome.com"}, new Comment{Email = "angularjs@google.com"}, new Comment{Email = "ps@sony.com"}}});

					context.SaveChanges();
				}
			}
		}
	}
}