using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quiz.Domain.Identity;
using Quiz.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Repository.Implementation
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityUser> _roleManager;

        public ApplicationUserRepository(UserManager<IdentityUser> userManager, RoleManager<IdentityUser> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public  IdentityResult Delete(string userId)
        {
            var user =  _userManager.FindByIdAsync(userId).GetAwaiter().GetResult();

            var result =  _userManager.DeleteAsync(user).GetAwaiter().GetResult();
            return result;
        }

       
        public IdentityUser Get(string userId)
        {
            var user = _userManager.FindByIdAsync(userId).GetAwaiter().GetResult();
            return user;
        }

        public async Task<IEnumerable<IdentityUser>> GetAll(string role)
        {
            var allUsers = _userManager.Users.ToList();
            var listUser = new List<IdentityUser>();
            foreach (var user in allUsers)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains(role))
                {
                    listUser.Add(user);
                }
            }
            return listUser;
        }

        public async Task ChangeUserRole(IdentityUser user, string changeTo)
        {
            var currentRoles = await _userManager.GetRolesAsync(user);
            //var currentRole = currentRoles.FirstOrDefault();
            await _userManager.RemoveFromRolesAsync(user, currentRoles);
            await _userManager.AddToRoleAsync(user, changeTo);
        }

     
    }
}
