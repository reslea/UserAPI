using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Models;

namespace UserAPI.DataAccess
{
    public class UserRepository
    {
        private static readonly List<UserModel> _users = new List<UserModel>
        {
            new UserModel {FName = "Sergey", LName = "Zhizhko", Email = "11r3start11@gmail.com"},
            new UserModel {FName = "John", LName = "Doe", Email = "john.doe@microsoft.com"}
        };

        public IEnumerable<UserModel> GetAll()
        {
            return _users;
        }

        public UserModel Get(int id)
        {
            return id > 0 && id <= _users.Count 
                ? _users[id-1] 
                : null;
        }

        public UserModel Get(string requestEmail)
        {
            return _users.FirstOrDefault(u => 
                u.Email.Equals(requestEmail, StringComparison.OrdinalIgnoreCase));
        }

        public UserModel Add(UserModel user)
        {
            var newId = _users.Count;
            _users.Add(user);
            user.Id = newId;
            return user;
        }
    }
}
