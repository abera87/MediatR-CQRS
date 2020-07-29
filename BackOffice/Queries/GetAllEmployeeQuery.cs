using System.Collections.Generic;
using BackOffice.ViewModel;
using MediatR;

namespace BackOffice.Queries
{
    public class GetAllEmployeeQuery:IRequest<List<EmployeeViewModel>>{

    }
}