using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using UserAPI.Models;

namespace UserAPI.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserModel>>
    {

    }
}
