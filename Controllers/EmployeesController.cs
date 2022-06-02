using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KefalosApi.Data;
using KefalosApi.Dtos;
using KefalosApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace KefalosApi.Controllers
{
    //api employees 
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IKefalosRepo _repository;
        private readonly IMapper _mapper;

        //constructor dependency injection
        //whenever you add a service into a controller you will have to do depedency injection in the constructor
        public EmployeesController(IKefalosRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //getting the infomation from the repository created for mockkefalosApi from the repository folder
        //private readonly MockKefalosRepo _repository = new MockKefalosRepo();

        // this method responds to api/employees
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeReadDto>> GetAllEmployees()
        {
            var employees = _repository.GetEmployees();

            return Ok(_mapper.Map<IEnumerable<EmployeeReadDto>>(employees));
        }

        // this method is responding to the GET api/employee/{id}
        [HttpGet("{id}", Name = "GetEmployeeById")]
        public ActionResult<EmployeeReadDto> GetEmployeeById(int id)
        {
            var employee = _repository.GetEmployeeById(id);
            if (employee != null)
            {
                return Ok(_mapper.Map<EmployeeReadDto>(employee));
            }

            return NotFound();

        }

        //POST api/employees
        [HttpPost]
        public ActionResult<EmployeeReadDto> CreateEmployee(EmployeeCreateDto employeeCreateDto)
        {
            var employeeModel = _mapper.Map<employee>(employeeCreateDto);
            _repository.CreateEmployee(employeeModel);
            _repository.SaveChanges();
            //setting it so that we can return code 201 and say created
            var employeeReadDto = _mapper.Map<EmployeeReadDto>(employeeModel);

            return CreatedAtRoute(nameof(GetEmployeeById), new { Id = employeeReadDto.Id }, employeeReadDto);
        }

        //PUT api/employee/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id, EmployeeUpdateDto employeeUpdateDto)
        {
            var employeeModelFromRepo = _repository.GetEmployeeById(id);
            if (employeeModelFromRepo == null)
            {
                return NotFound();
            }
            //in this update case mapping is done while the dto has data from the client and the model has data from the Db as we
            //this mapping has updated the employee model since the Sql repo class has no implemented
            _mapper.Map(employeeUpdateDto, employeeModelFromRepo);
            _repository.UpdateEmployee(employeeModelFromRepo);
            _repository.SaveChanges();

            return NoContent();

        }


        //PATCH api/employee/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<EmployeeUpdateDto> patchDoc)
        {
            var employeeModelFromRepo = _repository.GetEmployeeById(id);
            if (employeeModelFromRepo == null)
            {
                return NotFound();
            }

            var employeeToPatch = _mapper.Map<EmployeeUpdateDto>(employeeModelFromRepo);

            patchDoc.ApplyTo(employeeToPatch, ModelState);

            if (!TryValidateModel(employeeToPatch)) 
            { 
                return ValidationProblem(ModelState);
            }

            _mapper.Map(employeeToPatch, employeeModelFromRepo);
            _repository.UpdateEmployee(employeeModelFromRepo);
            _repository.SaveChanges();

            return NoContent();

        }
    }
}
