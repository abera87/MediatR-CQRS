using BackOffice.ViewModel;
using MediatR;

namespace BackOffice.Queries
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeViewModel>
    {
        public int empId;

        public GetEmployeeByIdQuery(int empId)
        {
            this.empId = empId;
        }
    }
}