using ResolutionActionSystem.Application.Models.Identity;

namespace Axis.IntranetSystem.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<Staff> GetEmployee(string userId);
        Task<(bool isSucceed, string userId)> CreateUserAsync(string userName, string password, string email, string firstName, string lastName, string phoneNumber);
        Task<(string userId, string firstName, string lastName, string UserName, string email, string phoneNumber)> GetUserDetailsAsync(string userId);
        Task<List<(string id, string firstName, string lastName, string userName, string email, string phoneNumber)>> GetAllUsersAsync();
        Task<bool> DeleteUserAsync(string userId);
    }
}
