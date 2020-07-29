using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Commands;
using BackOffice.Model;
using BackOffice.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EmployeeController : ControllerBase
    {
                private readonly IMediator mediator;

        public EmployeeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            var query = new GetAllEmployeeQuery();
            var result = await mediator.Send(query);
            return Ok(result);
            //// simple approch
            //return await _dBContext.Employee.ToListAsync();
        }

        [HttpGet("{empId}")]
        public async Task<ActionResult<Employee>> Get(int empId)
        {
            var query = new GetEmployeeByIdQuery(empId);
            var result = await mediator.Send(query);
            return Ok(result);
            //// simple approch
            //return await _dBContext.Employee.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Post([FromBody] Employee employee)
        {
            var command = new CreateEmployeeCommand
            {
                EmpId = employee.EmpId,
                Name = employee.Name,
                Address = employee.Address,
                Phone = employee.Phone
            };

            var result = await this.mediator.Send(command);
            return Ok(result);
        }
    }
}