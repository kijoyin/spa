using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SPA.Core.ViewModels;
using SPA.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SPA.Core.Services
{
    public class AutheticationService:IDisposable
    {
        private AuthRepository _repo = null;
        public AutheticationService()
        {
            _repo = new AuthRepository();
        }

        public async Task<IdentityResult> Register(UserViewModel userModel)
        {
            var model = userModel.ToDomainModel();
            return await _repo.RegisterUser(model);
        }

        public async Task<IdentityUser> FindUser(string username, string password)
        {
            return await _repo.FindUser(username, password);
        }

        public void Dispose()
        {
            _repo.Dispose();
        }
    }
}
