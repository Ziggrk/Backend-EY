using Backend.Infrastructure.Context;
using Backend.Infrastructure.Interface;
using Backend.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Services
{
    public class UserInfrastructure : IUserInfrastructure
    {
        public readonly EYDbContext _context;

        public UserInfrastructure(EYDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var userToDelete = await _context.User.FirstOrDefaultAsync(u => u.Id == id);
            if (userToDelete != null)
            {
                _context.User.Remove(userToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<User>> GetAllAsync()
        {
            var users = await _context.User.ToListAsync();
            return users;
        }

        public async Task<bool> LoginAsync(User user)
        {
            var auth = await _context.User.FirstOrDefaultAsync(u => u.username == user.username);
            if (auth != null)
            {
                if (auth.password == user.password)
                {
                    return true;
                }
                return false;
            }
            return false;

        }

        public async Task<bool> SaveAsync(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
