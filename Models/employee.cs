using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KefalosApi.Models
{
    public class employee
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Title { get; set; }
       // public DateTime DOB { get; set; }
        public String PhoneNumber { get; set; }
        public String Address { get; set; }
      //  public DateTime DateJoined { get; set; }
    }
}
