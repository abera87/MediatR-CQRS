using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BackOffice.Queries;
using BackOffice.ViewModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BackOffice.Handlers.QueryHandlers
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeViewModel>
    {
        private readonly BackOfficeDBContext dBContext;
        private readonly IMapper mapper;

        public GetEmployeeByIdQueryHandler(BackOfficeDBContext dBContext, IMapper mapper)
        {
            this.dBContext = dBContext;
            this.mapper = mapper;
        }
        public async Task<EmployeeViewModel> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await dBContext.Employee
                            .Where(x => x.EmpId == request.empId)
                            .ProjectTo<EmployeeViewModel>(mapper.ConfigurationProvider)
                            .FirstOrDefaultAsync();
        }
    }
}