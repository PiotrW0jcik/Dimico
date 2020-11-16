using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dimico.Server.Data;
using Dimico.Server.Features.Search.Models;
using Microsoft.EntityFrameworkCore;

namespace Dimico.Server.Features.Search
{
    public class SearchService : ISearchService
    {
        private readonly DimicoDbContext data;

        public SearchService(DimicoDbContext data) => this.data = data;


        public async Task<IEnumerable<ProfileSearchServiceModel>> Profile(string query)
            => await this.data
                .Users
                .Where(u => u.UserName.ToLower().Contains(query.ToLower()) ||
                            u.Profile.Name.ToLower().Contains(query.ToLower()))
                .Select(u => new ProfileSearchServiceModel
                {
                    UserId = u.Id,
                    UserName = u.UserName,
                    ProfilePhotoUrl = u.Profile.MainPhotoUrl
                })
                .ToListAsync();

    }
}
