using System;
using System.Collections.Generic;

namespace QueryEncapsulation.Web.Domain
{
	public class Post
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public DateTime PostDate { get; set; }

		public string Body { get; set; }

		public IList<Comment> Comments { get; set; }

		public Post()
		{
			Comments = new List<Comment>();
		}
	}
}