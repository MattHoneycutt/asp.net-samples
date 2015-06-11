namespace QueryEncapsulation.Web.Domain
{
	public class Comment
	{
		public int Id { get; set; }

		public string Email { get; set; }

		public string Body { get; set; }

		public Post Post { get; set; }
	}
}