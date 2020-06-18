using System;
using MediatR;
using UserAPI.DataAccess;
using UserAPI.Models;

namespace UserAPI.Queries
{
    public class GetUserByIdQuery : IRequest<UserModel>
    {
        public int Id { get; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}