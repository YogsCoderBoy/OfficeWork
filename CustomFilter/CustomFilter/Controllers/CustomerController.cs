using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace CustomFilter.Controllers
{

    public class CustomerController : Controller
    {
        
        public string GeneralUser()
        {
            return "General User";
        }

        [Authorize]
        public string User()
        {
            return "Authorized Users";
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}