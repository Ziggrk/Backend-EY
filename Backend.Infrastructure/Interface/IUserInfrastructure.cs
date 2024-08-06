using Backend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Interface
{
    public interface IUserInfrastructure
    {
        public Task<List<User>> GetAllAsync();
        public Task<bool> LoginAsync(User user);
        public Task<bool> SaveAsync(User user);
        public Task<bool> DeleteAsync(int id);
    }
}
