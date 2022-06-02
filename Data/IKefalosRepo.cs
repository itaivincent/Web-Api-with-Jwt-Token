using KefalosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace KefalosApi.Data
{
    public interface IKefalosRepo
    {
        //these are contract items which are promises as well
        bool SaveChanges();
        IEnumerable<employee> GetEmployees();
        employee GetEmployeeById(int id);
        void CreateEmployee(employee emp);
        void UpdateEmployee(employee emp);
    }
} 
