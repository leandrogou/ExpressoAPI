using System.Linq;
using ExpressoAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpressoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly ExpressoDbContext _expressoDbContext;

        public MenusController(ExpressoDbContext expressoDbContext)
        {
            _expressoDbContext = expressoDbContext;
        }
        [HttpGet]
        public IActionResult GetMenus()
        {
            var expressos = _expressoDbContext.Menus.Include("SubMenus");
            return Ok(expressos);
        }

        [HttpGet("{id}")]
        public IActionResult GetMenu(int id)
        {
            var menu = _expressoDbContext.Menus.Include("SubMenus").FirstOrDefault(s => s.Id == id);
            if (menu == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(menu);
            }
        }
    }
}