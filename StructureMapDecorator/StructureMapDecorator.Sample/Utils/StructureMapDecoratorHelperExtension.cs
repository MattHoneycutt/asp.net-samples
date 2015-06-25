using StructureMap.Pipeline;

namespace StructureMapDecorator.Sample.Utils
{
	public static class StructureMapDecoratorHelperExtension
	{
		public static DecoratorHelper<TTarget> Decorate<TTarget>(this SmartInstance<TTarget> instance)
		{
			return new DecoratorHelper<TTarget>(instance);
		}
	}
}