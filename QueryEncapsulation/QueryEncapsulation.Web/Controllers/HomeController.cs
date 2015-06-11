using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using QueryEncapsulation.Web.Data;
using QueryEncapsulation.Web.Models;

namespace QueryEncapsulation.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly AppDbContext _context;

		public HomeController(AppDbContext context)
		{
			_context = context;
		}

		public ActionResult Index()
		{
			var startDate = DateTime.Parse("6/1/2015");
			var endDate = DateTime.Parse("7/1/2015");
			var topPosts = _context
				.Posts.Where(x => x.PostDate >= startDate && x.PostDate < endDate &&
								  x.Comments.Count() >= 3
								  && x.Comments.Any(c => c.Email.Contains("@microsoft")))
				.Select(x => new TopPostModel
				{
					Title = x.Title,
					PostDate = x.PostDate,
					CommentCount = x.Comments.Count(),
					MicrosoftPosterAddresses =
						x.Comments.Where(c => c.Email.Contains("@microsoft.com")).Select(c => c.Email).ToList()
				})
				.ToArray();

			return View(topPosts);
		}

		public ActionResult WithAutoMapper()
		{
			var startDate = DateTime.Parse("6/1/2015");
			var endDate = DateTime.Parse("7/1/2015");
			var topPosts = _context
				.Posts.Where(x => x.PostDate >= startDate && x.PostDate < endDate &&
								  x.Comments.Count() >= 3
								  && x.Comments.Any(c => c.Email.Contains("@microsoft")))
				.Project().To<TopPostModel>()
				.ToArray();

			return View("Index", topPosts);
		}

		public ActionResult WithSingleExtensionMethod()
		{
			var startDate = DateTime.Parse("6/1/2015");
			var endDate = DateTime.Parse("7/1/2015");
			var topPosts = _context.Posts
				.TopPostsForDateRangeWithMSContributors(startDate, endDate)
				.Project().To<TopPostModel>()
				.ToArray();

			return View("Index", topPosts);
		}

		public ActionResult WithComposableExtensionMethod()
		{
			var startDate = DateTime.Parse("6/1/2015");
			var endDate = DateTime.Parse("7/1/2015");
			var topPosts = _context.Posts
				.Between(startDate, endDate)
				.WithAtLeastXComments(3)
				.WithMicrosoftCommenters()
				.Project().To<TopPostModel>()
				.ToArray();

			return View("Index", topPosts);
		}

		public ActionResult WithAQueryObject()
		{
			var startDate = DateTime.Parse("6/1/2015");
			var endDate = DateTime.Parse("7/1/2015");
			var topPosts = _context.Query<TopPostsQuery>().Execute(startDate, endDate);

			return View("Index", topPosts);
		}
	}
}