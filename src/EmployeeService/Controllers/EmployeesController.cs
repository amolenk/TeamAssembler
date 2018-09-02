using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        // GET api/employees
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Employee.All.Keys;
        }

        // GET api/employees/hulk
        [HttpGet("{id}")]
        public Employee Get(string alias)
        {
            return Employee.All[alias];
        }
    }
}
