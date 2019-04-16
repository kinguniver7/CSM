using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CSM.WebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace CSM.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, Authorize(Roles = "User")]
        public IActionResult TestUserRole()
        {
            return Ok(201);
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public IActionResult TestAdminRole()
        {
            return Ok(201);
        }

        [HttpGet, Authorize]
        public IActionResult Get(string code)
        {
            if (code == "401")
            {
                return StatusCode(401);
            }
            return Ok(new string[] { "John Doe", "Jane Doe" });
        }
    }
}
