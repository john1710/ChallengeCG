using Microsoft.AspNetCore.Mvc;
using Web.Data.Input;
using Web.Interfaces;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService service;

        public AccountController(IAccountService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var entities = await service.GetAll();
            return View(entities);
        }

        [HttpPost]
        [Route("Upsert")]
        public async Task<IActionResult> Upsert([FromForm] UpsertAccountInput input)
        {
            if(input.Id != 0)
            {
                await service.Update(input); 
            }
            else
            {
                await service.Create(input);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("Delete/{id:long}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            await service.Delete(id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Form([FromRoute]long id)
        {
            var isAddForm = true;
            if(id != 0)
            {
                isAddForm = false;
                ViewBag.isAdd = isAddForm;
                var entity = await service.GetById(id);
                var input = new UpsertAccountInput() { Id = entity.Id, Description = entity.Description, Name = entity.Name };
                return View(input);
            }
            ViewBag.isAdd = isAddForm;
            return View();
        }
    }
}
