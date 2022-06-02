using KefalosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KefalosApi.Data
{
    //this is an implementation class using DbContext to execute interfaces
    public class SqlKefalosRepo : IKefalosRepo
    {
        private readonly KefalosContext _context;

        //constructor dependency injection to access the DbContext for connecting to the DB in this class
        public SqlKefalosRepo(KefalosContext context)
        {
            _context = context; 
        }

        public void CreateEmployee(employee emp)
        {
            if(emp == null)
            {
                throw new ArgumentNullException(nameof(emp));
            }

            //this line now takes the object from the API and adds it to the DbSet
            _context.employees.Add(emp);
        }

        public employee GetEmployeeById(int id)
        {
            return _context.employees.FirstOrDefault(p => p.Id ==id);
        }

        public IEnumerable<employee> GetEmployees()
        {
            return _context.employees.ToList();
        }

        //this method is to activate actually saving the changes or data into the DB
        public bool SaveChanges()
        {
             return (_context.SaveChanges()>= 0);
        }

        public void UpdateEmployee(employee emp)
        {
         //nothing
        }
    }
}
