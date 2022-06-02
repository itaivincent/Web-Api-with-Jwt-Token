using KefalosApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KefalosApi.Data
{
    public class KefalosContext : DbContext
    {
        //setting the constructor to derive informaton or methods from base DbContext class
       public KefalosContext(DbContextOptions<KefalosContext>opt): base(opt)
        {

        }

        //create a representation of the Kefalos model 
        public DbSet<employee> employees { get; set; }
    }
}
