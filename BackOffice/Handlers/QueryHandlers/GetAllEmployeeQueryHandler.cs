using System.Collections.Generic;
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
    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, List<EmployeeViewModel>>
    {
        private readonly BackOfficeDBContext dBContext;
        private readonly IMapper mapper;

        public GetAllEmployeeQueryHandler(BackOfficeDBContext dBContext,IMapper mapper)
        {
            this.dBContext = dBContext;
            this.mapper = mapper;
        }
        public async Task<List<EmployeeViewModel>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            //return await dBContext.Employee.ToListAsync();

            return await dBContext.Employee
                            .ProjectTo<EmployeeViewModel>(mapper.ConfigurationProvider)
                            .ToListAsync();
        }
    }
}