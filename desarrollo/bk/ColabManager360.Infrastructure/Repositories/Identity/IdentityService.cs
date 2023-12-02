using ColabManager360.Domain.Entities.Auth.Responses;
using ColabManager360.Domain.Entities.Security.Models;
using ColabManager360.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ColabManager360.Infrastructure.Repositories.Identity
{
    internal class IdentityService : IIdentityService
    {
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;
        private readonly RoleManager<Roles> _RoleManager;
        private readonly ApplicationDbContext _DBcontext;

        public IdentityService(
            UserManager<Users> userManager,
            SignInManager<Users> signInManager,
            RoleManager<Roles> RoleManager,
            ApplicationDbContext DBcontext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _RoleManager = RoleManager;
            _DBcontext = DBcontext;
        }

        public async Task<UserResponse?> PasswordSignInAsync(string Username, string Password)
        {
            var result = await _signInManager.PasswordSignInAsync(Username, Password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {

                var response = await FindByNameAsync(Username);

                return response;

            }

            return null;

        }

        public async Task<UserResponse?> FindByNameAsync(string Username)
        {
            var response = new UserResponse();
        
            var user = await _userManager.FindByNameAsync(Username);

            if (user != null)
            {
                response.Email = user.Email ?? "";
                response.IsRegistered = false;
                response.Id = user.Id;
                response.GivenName = user.Email.Split("@")[0];

                var role = await _DBcontext.UserRoles.AsNoTracking().Where(u => u.UserId == user.Id).FirstOrDefaultAsync();

                if (role != null)
                {
                    response.Role = role.RoleId;
                }

                user.Person = await _DBcontext.PersonInformation.AsNoTracking().Where(u => u.WorkEmail == user.Email).FirstOrDefaultAsync();

                if (user.Person != null)
                {
                    response.GivenName =  $"{user.Person.FirstName1} {user.Person.FirstName2}" ;
                    response.FamilyName = $"{user.Person.LastName1} {user.Person.LastName2}";
                    response.IsRegistered = true;
                    response.PersonId = user.Person.Uid.ToString();
                    response.Position = user.Person.Position;
                }

            }

            return response;

        }

        public async Task<UserResponse?> CreateAsync(Users User, string RoleId = "COLAB")
        {
            var response = new UserResponse();

            var rol = await _RoleManager.FindByIdAsync(RoleId);

            if (rol == null)
            {
                throw new ArgumentException("No hay permisos establecidos para crear 'Usuario' !");

            }

            var result = await _userManager.CreateAsync(User);

            if (result.Succeeded)
            {
                response.Email = User.Email ?? "";
                response.IsRegistered = false;
                response.Id = User.Id;
                response.GivenName = User.Email.Split("@")[0];

                result = await _userManager.AddToRoleAsync(User, rol?.Name);

                if (result.Succeeded)
                {

                    response.Role = rol.Id;

                    await _userManager.SetLockoutEnabledAsync(User, false);

                  
                }

            }

            return response;
        }
        public async Task<UserResponse?> CreateWithPasswordAsync(Users User, string Password)
        {
            var response = new UserResponse();

            var rol = await _RoleManager.FindByNameAsync("Colaborador");

            if (rol == null)
            {
                throw new ArgumentException("No hay permisos establecidos para crear 'Usuario' !");

            }

            var result = await _userManager.CreateAsync(User, Password);

            if (result.Succeeded)
            {
                response.Email = User.Email ?? "";
                response.IsRegistered = false;
                response.Id = User.Id;
                response.GivenName = User.Email.Split("@")[0];

                result = await _userManager.AddToRoleAsync(User, rol?.Name);

                if (result.Succeeded)
                {

                    response.Role = rol.Id;
                    await _userManager.SetLockoutEnabledAsync(User, false);
                }

            }

            return response;

        }

        public async Task<UserResponse?> EditUserAsync(Users User, string rolId)
        {
            var response = new UserResponse();

            var rol = await _RoleManager.FindByIdAsync(rolId);

            if (rol == null)
            {
                throw new ArgumentException("No hay permisos establecidos para crear 'Usuario' !");

            }

            var resultUser = await _userManager.FindByNameAsync(User.Email);

            if (resultUser != null)
            {

                await _userManager.SetLockoutEnabledAsync(resultUser, User.LockoutEnabled);

                var userRoles = await _userManager.GetRolesAsync(resultUser);

                if (userRoles.Any())
                {
                  await _userManager.RemoveFromRolesAsync(resultUser, userRoles);  
                }               

                var result = await _userManager.AddToRoleAsync(resultUser, rol?.Name);

                if (result.Succeeded)
                {
                    response.Id = resultUser.Id;
                    response.Role = rol.Id;
                }

            }

            return response;

        }

        public Task<string?> GetUserNameAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(string userId, string role)
        {
            throw new NotImplementedException();
        }

    }
}
