using Axis.IntranetSystem.Application.Contracts.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ResolutionActionSystem.Application.Exceptions;
using ResolutionActionSystem.Application.Models.Identity;
using ResolutionActionSystem.Identity.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolutionActionSystem.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<SystemUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserService(UserManager<SystemUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<(bool isSucceed, string userId)> CreateUserAsync(string userName, string password, string email, string firstName, string lastName, string phoneNumber)
        {
            var user = new SystemUser()
            {
                FirstName = firstName,
                LastName = lastName,
                UserName = userName,
                Email = email,
                PhoneNumber = phoneNumber,
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                throw new Exception("Failed to create user. Choose unique username and email and ensure you meet password policy"); ;
            }

            return (result.Succeeded, user.Id);
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
            {
                throw new NotFoundException("User not found");
                //throw new Exception("User not found");
            }

            if (user.UserName == "system" || user.UserName == "admin")
            {
                throw new Exception("You can not delete system or admin user");
                //throw new BadRequestException("You can not delete system or admin user");
            }
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<List<(string id, string firstName, string lastName, string userName, string email, string phoneNumber)>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.Select(x => new
            {
                x.Id,
                x.FirstName,
                x.LastName,
                x.UserName,
                x.Email,
                x.PhoneNumber
            }).ToListAsync();
            return users.Select(user => (user.Id, user.FirstName, user.LastName, user.UserName, user.Email, user.PhoneNumber)).ToList();
        }

        public async Task<Staff> GetEmployee(string userId)
        {
            var employee = await _userManager.FindByIdAsync(userId);
            return new Staff
            {
                Email = employee.Email,
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                PhoneNumber = employee.PhoneNumber,
            };
        }
        public async Task<(string userId, string firstName, string lastName, string UserName, string email, string phoneNumber)> GetUserDetailsAsync(string userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }
            return (user.Id, user.FirstName, user.LastName, user.UserName, user.Email, user.PhoneNumber);
        }
    }
}
