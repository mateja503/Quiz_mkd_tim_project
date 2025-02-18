using Microsoft.AspNetCore.Identity;
using Quiz.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Repository.Interface
{
    public interface IApplicationUserRepository
    {
        public Task<IEnumerable<IdentityUser>> GetAll(string role);


        public IdentityUser Get(string userId);

        public IdentityResult Delete(string userId);

        public void ChangeUserRole(IdentityUser user,string changeTo);
        
    }
}
