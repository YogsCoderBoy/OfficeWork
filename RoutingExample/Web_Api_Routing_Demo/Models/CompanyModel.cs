using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Web_Api_Routing_Demo.Models
{
    public class CompanyModel
    {
        [Key]
        public int CompanyId { get; set; }
        [Required]
        [MaxLength(20)]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Location { get; set; }

        public ICollection<EmployeeModel> Employees { get; set; }
    }
    public class product
    {
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Price { get; set; }
        public string[] Sizes { get; set; }

    }
}
