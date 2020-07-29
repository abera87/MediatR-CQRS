using System.Threading;
using System.Threading.Tasks;
using BackOffice.Commands;
using BackOffice.Model;
using MediatR;

namespace BackOffice.Handlers.CommandHandlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly BackOfficeDBContext dBContext;
        private readonly IMediator mediator;

        public CreateEmployeeCommandHandler(BackOfficeDBContext dBContext, IMediator mediator)
        {
            this.dBContext = dBContext;
            this.mediator = mediator;
        }

        public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var emp = new Employee
            {
                EmpId = request.EmpId,
                Name = request.Name,
                Address = request.Address,
                Phone = request.Phone
            };
            dBContext.Add(emp);

            await dBContext.SaveChangesAsync();

            return emp;
        }
    }
}