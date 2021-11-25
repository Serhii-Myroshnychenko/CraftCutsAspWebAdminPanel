using CraftCutsAspWebAdminPanel.Data;
using CraftCutsAspWebAdminPanel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftCutsAspWebAdminPanel.Controllers
{
    public class LoginController : Controller
    {
        private readonly CraftCutsNewDB2Context _context;

        public LoginController(CraftCutsNewDB2Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            Login login = new Login();
            return View(login);
        }
        [HttpPost]

        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                ;
                if(_context.Admins.Where(m => m.Login == login.LoginAdm && m.Password == login.Password).FirstOrDefault() == null)
                {
                    ModelState.AddModelError("Error", "Invalid login or password");
                    return View();
                }
                else
                {
                    
                    
                    HttpContext.Session.SetString("Login",login.LoginAdm);
                    return RedirectToAction("Index","Home","Index");
                }
                  
            }
            return View();
        }
    }
}
