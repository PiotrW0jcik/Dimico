using System.Threading.Tasks;
using Dimico.Server;
using Dimico.Server.Data;
using Dimico.Server.Data.Models;
using Dimico.Server.Features.Identity;
using Dimico.Server.Features.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace Dimico.Tests
{

    public class IdentityControllerTests
    {


        public Mock<UserManager<User>> GetMockUserManager()
        {
            var userStoreMock = new Mock<IUserStore<User>>();
            return new Mock<UserManager<User>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);
        }
        

        [Fact]
        public async Task Register_should_succed()
        {
            var settingsMock = new Mock<IOptions<AppSettings>>();
            var userManagerMock = GetMockUserManager();
            userManagerMock.Setup(x => x.CreateAsync(It.IsAny<User>(), "passwordtest1")).Returns(Task.FromResult(IdentityResult.Success));
            var identityMock = new Mock<IIdentityServices>();

            var controllerMock = new Mock<IdentityController>(userManagerMock.Object, identityMock.Object, settingsMock.Object);
            controllerMock.CallBase = true;

            var model = new RegisterRequestModel
            {
                Email = "email@email.email",
                Password = "passwordtest1",
                UserName = "username"
            };

             var actionResult =  await controllerMock.Object.Register(model);
             var result = actionResult as IActionResult;

           
            Assert.NotNull(result);
            Assert.IsType<OkResult>(result);

        }

    }
}
