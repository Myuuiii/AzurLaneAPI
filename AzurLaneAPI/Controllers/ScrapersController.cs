using AzurLaneClasses;
using Microsoft.AspNetCore.Mvc;

namespace AzurLaneAPI.Controllers
{
    public class ScrapersController : Controller
    {
        private AzurLaneDbContext _context;

		public ScrapersController(AzurLaneDbContext context)
		{
			_context = context;
		}
	}
}