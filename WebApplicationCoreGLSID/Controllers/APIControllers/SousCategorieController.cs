using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationCoreGLSID.ServicesContracts;

namespace WebApplicationCoreGLSID.Controllers.APIControllers
{
   
    public class SousCategorieController : CustomController
    {
        private readonly ISousCategorieService sousCategorieService;
        public SousCategorieController(ISousCategorieService sousCategorieService)
        {
            this.sousCategorieService = sousCategorieService;
        }

        [HttpGet]
        public IActionResult GetAllssCat()
        {
            var x = sousCategorieService.GetAll();
            return Ok(x);
        }
        [HttpGet]
        [Route("/api/TestOrder")]
        public IActionResult GetOrder()
        {
            var test = sousCategorieService.GetOrderBy();
            return Ok(test);
        }
        [HttpGet]
        [Route("{name}")]
        public IActionResult GetByCatName(string name)
        {
            var test = sousCategorieService.GetssCatByCatName(name);
            return Ok(name);
        }
    }
}
