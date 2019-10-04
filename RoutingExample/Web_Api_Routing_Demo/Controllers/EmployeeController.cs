using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_Api_Routing_Demo.Models;

namespace Web_Api_Routing_Demo.Controllers
{
    [ApiController]
    [Route("api/companies/{id}/employees")]

    public class EmployeeController : Controller
    {
        private CompanyContext _Context;
        public EmployeeController(CompanyContext company)
        {
            _Context = company;
        }

        public List<EmployeeModel> Get(int id)
        {
            return _Context.employee.Where(x => x.CompanyId == id).ToList();
        }
        [HttpPost]
        public EmployeeModel Post([FromBody] EmployeeModel model)
        {
            _Context.Add(model);
            _Context.SaveChanges();
            return model;
        }
        [HttpDelete]
        public EmployeeModel Delete(int id, EmployeeModel model)
        {
            if (id > 0)
            {
                var employeenyid = _Context.employee.Where(x => x.EmployeeId == id).FirstOrDefault();
                _Context.Remove(employeenyid);
                _Context.SaveChanges();
            }
            return model;
        }
        [HttpPut]
        public void Put(int id, [FromBody] EmployeeModel model)
        {
            var existingEmployee = _Context.employee.Where(x => x.EmployeeId == id).FirstOrDefault();
            if (existingEmployee != null)
            {
                existingEmployee.EmployeeName = model.EmployeeName;
                existingEmployee.Address = model.Address;
                _Context.SaveChanges();
            }
        }

        //[HttpGet]
        // public List<EmployeeModel> Get(int id)
        // {          
        //     return _Context.employee.Where(x => x.CompanyId == id).ToList();
        // }
        
    }
}