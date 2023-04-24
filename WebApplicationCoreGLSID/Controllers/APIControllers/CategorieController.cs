using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationCoreGLSID.Models;
using WebApplicationCoreGLSID.Models.DTO;
using WebApplicationCoreGLSID.ServicesContracts;

namespace WebApplicationCoreGLSID.Controllers.APIControllers
{
    
    public class CategorieController : CustomController
    {
        private readonly ICategorieService categorieService;
        public CategorieController(ICategorieService categorieService)

        {
            this.categorieService = categorieService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCat()
        {
            var c = await categorieService.GetAll();
            return Ok(c);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewCat(CategorieDTO c)
        {
            var cat= await categorieService.Create(c);
            return Ok(cat);
        }
        [HttpPut]
        public IActionResult EditCat(Guid id, CategorieDTO c)

        {
            var t = categorieService.Edit(id, c);
            return Ok(t);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCat(Guid id)
        {
            categorieService.Delete(id);
            return Ok();
        }
    }
}
