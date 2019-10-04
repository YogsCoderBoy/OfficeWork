using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Web_Api_Routing_Demo.Models;

namespace Web_Api_Routing_Demo.Controllers
{
   // [Route("api/company/{id?}")]
    [Route("api/companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private CompanyContext _Context;
        public CompanyController(CompanyContext company)
        {
            _Context = company;
        }

        //Done
        //[Route("{id?}")]
        //public List<CompanyModel> Get(int id)
        //{
        //    if (id != 0)
        //    {
        //        return _Context.company.Where(x => x.CompanyId == id).ToList();
        //    }
            
        //    return _Context.company.ToList();
        //}

        //Done
        [HttpPost]
        public CompanyModel Post([FromBody] CompanyModel model)
        {
            _Context.Add(model);
            _Context.SaveChanges();
            return model;
        }
        //Done
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id > 0)
            {
                var Companybyid = _Context.company.Where(x => x.CompanyId == id).FirstOrDefault();
                if (Companybyid != null)
                {
                    _Context.company.Remove(Companybyid);

                    _Context.SaveChanges();
                }
            }
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CompanyModel model)
        {
            var existingCompany = _Context.company.Where(x => x.CompanyId == id).FirstOrDefault();
            if (existingCompany != null)
            {
                existingCompany.CompanyName = model.CompanyName;
                existingCompany.Location = model.Location;
                _Context.SaveChanges();
            }

        }
        [HttpGet]
        [Route("get/tocken")]
        public string GetToken(CompanyModel company)
        {
            bool isCompanyExit = _Context.company.Any(x => x.Location == company.Location && x.CompanyName == company.CompanyName);
            if (isCompanyExit)
            {
                Guid guid = Guid.NewGuid();
                return guid.ToString();
            }
            else
            {
                return "Company Does Not Exist";
            }
        }
    }
}