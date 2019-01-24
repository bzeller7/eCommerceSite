using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly CommerceContext _context;

        public AccountController(CommerceContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Member m)
        {
            if (ModelState.IsValid)
            {
                //add to db
                MemberDb.AddMember(m, _context);

                //redirect to index page
                return RedirectToAction("Index", "Home");
            }

            //returning view, with error messages
            return View(m);
        }
    }
}