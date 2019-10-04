using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Web_Api_Routing_Demo.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(20)]
        public string EmployeeName { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }

        [Required]
        public int CompanyId { get; set; }

        public CompanyModel Company { get; set; }
    }
}
