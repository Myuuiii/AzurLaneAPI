using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AzurLaneAPI.Controllers
{
    public class DocsController : Controller
    {
        [HttpGet("/")]
        public async Task<ActionResult> Docs()
        {
            return View("/Views/Index.cshtml");
        }
    }
}