using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AngularPassingData.Helpers
{
	public static class JsonHelpers
	{
		public static IHtmlString ToJson<T>(this T obj)
		{
			var settings = new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			};
			return MvcHtmlString.Create(JsonConvert.SerializeObject(obj, settings));
		}
	}
}