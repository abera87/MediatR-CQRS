using System.Collections.Generic;
using System.Threading.Tasks;
using BackOffice.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackOffice.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly BackOfficeDBContext _dBContext;
        public EmployeeController(BackOfficeDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<ActionResult<IEnumerable<Employee>>> GetTask()
        {
            return await _dBContext.Employee.ToListAsync();
        }
    }
}