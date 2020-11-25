using System.Threading.Tasks;
using Dimico.Server.Data;
using Dimico.Server.Data.Models;
using Dimico.Server.Features.Identity.Models;
using Dimico.Server.Features.Plans;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Dimico.Tests
{

    public class PlansTest
    {
        [Fact]
        public async Task Register_should_succed()
        {
            var dataMock = new Mock<DimicoDbContext>();
          
            var planeServiceMock = new Mock<PlanService>(dataMock);
            planeServiceMock.Setup(x => x.GetByIdAndByUserId(It.IsAny<int>(),It.IsAny<string>()))
                .Returns( new Task<Plan>(() 
                    => new Plan(){ 
                        Id = 1,
                        ImageUrl = "imageUrl",
                        Description = "description",
                        UserId = "1"
                    }) );

            //var result = planeServiceMock.Object.Create("djasghkdhsa", "dsadhsads", "dsadsads");
           

        }

    }
}