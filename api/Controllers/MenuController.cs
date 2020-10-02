using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepository _menuRepository;

        public MenuController(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        [HttpGet]
        [Route("")]
        public ActionResult GetMenu()
        {
            var menu = _menuRepository.GetMenu();
            return Ok(menu);
        }
    }
}
