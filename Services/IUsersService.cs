using RedBrowBackend.Models;

namespace RedBrowBackend.Services
{
    public interface IUsersService
    {
        Task<List<Users>> GetAllUsers();
        Task<Users?> GetSingleUser(int id);
        Task<List<Users>?> AddUser(Users users);
        Task<List<Users>?> UpdateUser(int id, Users users);
        Task<List<Users>?> DeleteUser(int id);
    }
}
