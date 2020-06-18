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
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserModel>
    {
        private readonly UserRepository _userRepository;

        public GetUserByIdHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return _userRepository.Get(request.Id+1);
        }
    }
}
