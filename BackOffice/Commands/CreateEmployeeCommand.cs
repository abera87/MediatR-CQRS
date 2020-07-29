using System.Threading;
using System.Threading.Tasks;
using BackOffice.Model;
using MediatR;

namespace BackOffice.Commands
{
    public class CreateEmployeeCommand : IRequest<Employee>
    {
        public int? EmpId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}