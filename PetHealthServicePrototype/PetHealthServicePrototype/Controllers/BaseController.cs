using System.Web.Mvc;
using PetHealthServicePrototype.Models;

namespace PetHealthServicePrototype.Controllers
{
    public class BaseController : Controller
    {
        public PetHealthServiceEntities context;

        public BaseController()
        {
            context = new PetHealthServiceEntities();
        }
    }
}