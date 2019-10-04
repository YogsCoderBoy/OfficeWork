using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DemoOfWebApi.Model;
using DemoOfWebApi.Inerface;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoOfWebApi.Controllers
{
    [Route("api/[Controller]")]
    public class StudentController : Controller
    {

        private readonly List<StudentModel> _student = new List<StudentModel>()
        {
            new StudentModel
            {
                StudentId=1,
                FirstName="Yogesh",
                LastName="Parmar"
            },
            new StudentModel{ StudentId=2,FirstName="Binal",LastName="Patel"}
        };
        [Route("Index")]
        public List<StudentModel> Index()
        {
            return _student;
        }

        [CustomAuthorization]
        [HttpPost]
        [Route("student")]
        public IActionResult PostStudent([FromForm] StudentModel student)
        {
            return Content("OK");
        }
        //[HttpGet]
        [Route("FromBody")]
        public StudentModel GetStudent([FromBody] StudentModel student)
        {
            return student;
        }
        [Route("FromService")]
        [HttpPost]
        public string TestStudenyService([FromServices] ITestStudent test)
        {
            var s = test.TestFromService();
            return s;
        }
        [HttpPost]
        [Route("FromQuery")]
        public string FromQuery([FromQuery] string Test)
        {
            return "FromQuery";
        }
        [HttpGet]
        [Route("FromRoute/{id}")]
        public string FromRoute([FromRoute] int id, [FromHeader] string TestHeader)
        {
            return "FromRoute";
        }
        [HttpPost]
        [Route("FromHeader")]
        public string FromHeader([FromHeader] string TestHeader, [FromHeader]int id)
        {
            return TestHeader;
        }
        //[HttpGet]
        //[Route("FromUri")]
        //public string FromUri([FromUri] string TestUri)
        //{
        //    return "";
        //}
    }
}
