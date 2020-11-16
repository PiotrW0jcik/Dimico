using System.Collections.Generic;
using System.Threading.Tasks;
using Dimico.Server.Features.Search.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dimico.Server.Features.Search
{
    public class SearchController : ApiController
    {
        private readonly ISearchService search;

        public SearchController(ISearchService search) => this.search = search;

        [HttpGet]
        [AllowAnonymous]
        [Route(nameof(Profiles))]
        public async Task<IEnumerable<ProfileSearchServiceModel>> Profiles(string query)
            => await this.search.Profile(query);
    }
}
