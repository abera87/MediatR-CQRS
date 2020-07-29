using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BackOffice.Model;
using BackOffice.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BackOffice.Handlers.QueryHandlers
{
    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, List<Employee>>
    {
        private readonly BackOfficeDBContext dBContext;

        public GetAllEmployeeQueryHandler(BackOfficeDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public async Task<List<Employee>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            return await dBContext.Employee.ToListAsync();
        }
    }
}