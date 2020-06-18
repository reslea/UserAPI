using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using UserAPI.DataAccess;
using UserAPI.Models;

namespace UserAPI.Commands
{
    public class CreateUserCommand : IRequest<UserModel>
    {
        public string FName { get; set; }

        public string LName { get; set; }

        public string Email { get; set; }
    }

    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserModel>
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserHandler(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var sameEmailUser = _userRepository.Get(request.Email);
            if(sameEmailUser != null)
                throw new ArgumentException("user with this email already created");

            var model = _mapper.Map<UserModel>(request);
            return _userRepository.Add(model);
        }
    }
}
