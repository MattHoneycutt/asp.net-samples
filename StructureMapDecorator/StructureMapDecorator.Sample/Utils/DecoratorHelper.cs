using StructureMap.Interceptors;
using StructureMap.Pipeline;

namespace StructureMapDecorator.Sample.Utils
{
	public class DecoratorHelper<TTarget>
	{
		private readonly SmartInstance<TTarget> _instance;

		public DecoratorHelper(SmartInstance<TTarget> instance)
		{
			_instance = instance;
		}

		public DecoratedInstance<TTarget> With<TDecorator>()
		{
			ContextEnrichmentHandler<TTarget> decorator = (ctx, t) =>
			                                              	{
			                                              		var pluginType = ctx.BuildStack.Current.RequestedType;

			                                              		ctx.RegisterDefault(pluginType, t);

			                                              		return ctx.GetInstance<TDecorator>();
			                                              	};

			_instance.EnrichWith(decorator);

			return new DecoratedInstance<TTarget>(_instance, decorator);
		}
	}
}