using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dimico.Server.Infrastructure.Services
{
    public interface ICurrentUserService
    {
        string GetUserName();

        string GetId();
    }
}
