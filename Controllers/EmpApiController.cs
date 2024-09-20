using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using efcore.database;
using efcore.DTOs;
using efcore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpApiController : ControllerBase
    {
        private readonly EmpDbContext empDbContext;
        private readonly IMapper mapper;
        public EmpApiController(EmpDbContext _empDbContext, IMapper _mapper)
        {
            this.empDbContext = _empDbContext;
            this.mapper = _mapper;
        }

        [HttpGet("getEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await empDbContext.employee.ToListAsync();
            var result = mapper.Map<List<EmpDetailsDTO>>(employees);

            return Ok(result);
        }

        [HttpGet("{Id}")]
        public IActionResult GetEmployeeById(int Id)
        {
            var employee = empDbContext.employee.Find(Id);
            var result = mapper.Map<EmpDetailsDTO>(employee);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("createEmp")]
        public IActionResult CreateEmployee(EmpRegisterDTO emp)
        {
             var e = mapper.Map<Employee>(emp);
             empDbContext.Add(e);

            // var e = new Employee(){
            //     Name = emp.Name,
            //     PhoneNo = emp.PhoneNo,
            //     Email = emp.Email,
            //     Password = emp.Password,
            //     Salary = emp.Salary,
            //     DepartmentId = emp.DepartmentId
            // };
            // empDbContext.Add(e);
            var result = empDbContext.SaveChanges();
            return Ok(result);
        }
    }
}