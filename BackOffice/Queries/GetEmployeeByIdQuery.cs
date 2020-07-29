using BackOffice.Model;
using MediatR;

namespace BackOffice.Queries
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public int empId;

        public GetEmployeeByIdQuery(int empId)
        {
            this.empId = empId;
        }
    }
}