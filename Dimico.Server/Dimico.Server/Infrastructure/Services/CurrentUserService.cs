using System.Security.Claims;
using Dimico.Server.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;

namespace Dimico.Server.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {

        private readonly ClaimsPrincipal user;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor) 
            => this.user = httpContextAccessor.HttpContext?.User;


        public string GetUserName()
            => this.user
                ?.Identity
                ?.Name;

        public  string GetId()
            => this.user?.GetId();

    }
}
