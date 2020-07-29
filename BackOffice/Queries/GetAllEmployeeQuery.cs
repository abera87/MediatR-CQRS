using System.Collections.Generic;
using BackOffice.Model;
using MediatR;

namespace BackOffice.Queries   
{
    public class GetAllEmployeeQuery:IRequest<List<Employee>>{

    }
}