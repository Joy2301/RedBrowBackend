using Microsoft.EntityFrameworkCore;
using RedBrowBackend.Data;
using RedBrowBackend.Models;

namespace RedBrowBackend.Services
{
    public class UsersService : IUsersService
    {
        private readonly DataContext _dataContext;
        public UsersService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Users>> GetAllUsers()
        {
            var Users = await _dataContext.Users.ToListAsync();
            return Users;
        }

        public async Task<Users?> GetSingleUser(int id)
        {
            var Users = await _dataContext.Users.FindAsync(id);
            if (Users is null)
                return null;
            return Users;
        }
        public async Task<List<Users>?> AddUser(Users users)
        {
            _dataContext.Users.Add(users);
            await _dataContext.SaveChangesAsync();
            return await _dataContext.Users.ToListAsync();
        }
        public async Task<List<Users>?> UpdateUser(int id, Users users)
        {
            var Users = await _dataContext.Users.FindAsync(id);
            if (Users is null)
                return null;
            Users.FirstName = users.FirstName;
            Users.LastName = users.LastName;
            Users.Email = users.Email;
            Users.Age = users.Age;
            Users.Country = users.Country;

            await _dataContext.SaveChangesAsync();
            return await _dataContext.Users.ToListAsync();
        }
        public async Task<List<Users>?> DeleteUser(int id)
        {
            var Users = await _dataContext.Users.FindAsync(id);
            if (Users is null)
                return null;
            _dataContext.Users.Remove(Users);

            await _dataContext.SaveChangesAsync();
            return await _dataContext.Users.ToListAsync();
        }
    }
}
