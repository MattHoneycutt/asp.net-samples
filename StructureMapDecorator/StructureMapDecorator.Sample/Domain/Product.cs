namespace StructureMapDecorator.Sample.Domain
{
	public class Product
	{
		public int ID { get; set; }

		public override string ToString()
		{
			return "Product " + ID;
		}
	}
}