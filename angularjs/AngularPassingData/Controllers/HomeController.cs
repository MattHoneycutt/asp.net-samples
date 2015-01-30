using System.Web.Mvc;
using AngularPassingData.Models;

namespace AngularPassingData.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
	        var models = new[]
	        {
		        new PersonViewModel
		        {
			        Name = "Aragorn",
			        Occupation = "King of Gondor",
			        Age = 87
		        },
		        new PersonViewModel
		        {
			        Name = "Legolas",
			        Occupation = "Elf with a Bow",
			        Age = 2931
		        },
		        new PersonViewModel
		        {
			        Name = "Bilbo Baggins",
			        Occupation = "Burglar",
			        Age = 111
		        },
	        };

	        return View(models);
        }
    }
}