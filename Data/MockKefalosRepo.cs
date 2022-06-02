using KefalosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KefalosApi.Data
{
    public class MockKefalosRepo : IKefalosRepo
    {
        public void CreateEmployee(employee emp)
        {
            throw new NotImplementedException();
        }

        public employee GetEmployeeById(int id)
        {
            return new employee { Id = 0, Name = "Temba Mhokore", Title = "Software Developer", PhoneNumber = "078758376", Address = "125 Harare" };
        }

        public IEnumerable<employee> GetEmployees()
        {
            var employees = new List<employee>
            {
                new employee { Id = 1, Name = "Itai Mhokore", Title = "Software Developer", PhoneNumber = "078768376", Address = "135 Harare" },
                new employee { Id = 2, Name = "Vincent Mhokore", Title = "Software Developer", PhoneNumber = "078778376", Address = "125 Harare" },
                new employee { Id = 3, Name = "Itai Moyo", Title = "Software Developer", PhoneNumber = "078758976", Address = "145 Harare" }
            };

            return employees;
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(employee emp)
        {
            throw new NotImplementedException();
        }
    }
}
