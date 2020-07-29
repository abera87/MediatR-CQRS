using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BackOffice.Model;
using BackOffice.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BackOffice.Handlers.QueryHandlers
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly BackOfficeDBContext dBContext;

        public GetEmployeeByIdQueryHandler(BackOfficeDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await dBContext.Employee.Where(x => x.EmpId == request.empId).FirstOrDefaultAsync();
        }
    }
}