using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;

namespace Api.Services.Services
{
    public class UserService : IUserService
    {
        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> Post(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> Put(UserEntity user)
        {
            throw new NotImplementedException();
        }
    }
}