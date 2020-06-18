using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UserAPI.DataAccess;
using UserAPI.Models;
using UserAPI.Queries;

namespace UserAPI.Handlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserModel>>
    {
        private readonly UserRepository _userRepository;

        public GetAllUsersHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return _userRepository.GetAll();
        }
    }
}
