using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dimico.Server.Features.Search.Models;

namespace Dimico.Server.Features.Search
{
    public interface ISearchService
    {
        Task<IEnumerable<ProfileSearchServiceModel>> Profile(string query);
    }
}
