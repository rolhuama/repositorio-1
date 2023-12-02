using ColabManager360.Domain.Entities.Auth.Responses;
using ColabManager360.Domain.Entities.Security.Models;

namespace ColabManager360.Infrastructure.Repositories.Identity
{
    public interface IIdentityService
    {
        Task<UserResponse?> CreateAsync(Users User, string RoleId = "COLAB");
        Task<UserResponse?> CreateWithPasswordAsync(Users User, string Password);
        Task<UserResponse?> EditUserAsync(Users User, string rolId);
        Task<UserResponse?> FindByNameAsync(string Username);
        Task<string?> GetUserNameAsync(string userId);

        Task<bool> IsInRoleAsync(string userId, string role);
        Task<UserResponse?> PasswordSignInAsync(string Username, string Password);

    }
}
