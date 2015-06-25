namespace StructureMapDecorator.Sample.Domain
{
	public class User
	{
		public string UserName { get; set; }

		public override string ToString()
		{
			return UserName;
		}
	}
}