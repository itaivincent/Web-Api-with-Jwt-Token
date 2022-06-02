using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KefalosApi.Dtos
{
    public class EmployeeReadDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Title { get; set; } 
        public String PhoneNumber { get; set; }
        public String Address { get; set; }
    }
}
