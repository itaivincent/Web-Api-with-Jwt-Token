using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KefalosApi.Dtos
{
    public class EmployeeCreateDto
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public String Title { get; set; }
        [Required]
        public String PhoneNumber { get; set; }
        [Required]
        public String Address { get; set; }
    }
}
