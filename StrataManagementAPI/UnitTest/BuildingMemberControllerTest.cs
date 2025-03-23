using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using StrataManagementAPI.Controllers;
using StrataManagementAPI.DataAccess;
using StrataManagementAPI.Models;
using StrataManagementAPI.Services;
using System.Security.Claims;

namespace StrataManagementAPI.UnitTest
{
    [TestFixture]
    public class BuildingMemberControllerTest
    {
        private Mock<IBuildingMemberService> _buildingMemberService;
        private BuildingMemberController _buildingMemberController;
        private ClaimsPrincipal _user;

        [SetUp]
        public void Setup()
        {
            _buildingMemberService = new Mock<IBuildingMemberService>();
            _buildingMemberController = new BuildingMemberController(_buildingMemberService.Object);
            _user = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, "user123")
            }, "Test"));
            _buildingMemberController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = _user }
            };
        }

        [Test]
        public async Task GetMyBuildings_ReturnsOkResult_WithListOfMyBuildings()
        {
            var buildings = new List<Building> { new Building { Id = "1", Name = "Building A" } };
            _buildingMemberService.Setup(s => s.GetMyBuilding(_user)).ReturnsAsync(buildings);

            var okResult = await _buildingMemberController.GetMyBuilding() as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult, Is.InstanceOf<OkObjectResult>());

            var results = okResult.Value as List<Building>;
            Assert.That(results.Count, Is.EqualTo(1));
            Assert.That(results.First().Name, Is.EqualTo("Building A"));

            _buildingMemberService.Verify(s => s.GetMyBuilding(_user), Times.Once);
        }

        [Test]
        public async Task GetMyMaintenanceRequests_ReturnsOkResult_WithListOfMyRequests()
        {
            var requests = new List<MaintenanceRequest> { new MaintenanceRequest { Id = "1", Description = "Leaky faucet" } };
            _buildingMemberService.Setup(s => s.GetMyRequests(_user)).ReturnsAsync(requests);

            var okResult = await _buildingMemberController.GetMyRequests() as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult, Is.InstanceOf<OkObjectResult>());

            var results = okResult.Value as List<MaintenanceRequest>;
            Assert.That(results.Count, Is.EqualTo(1));
            Assert.That(results.First().Description, Is.EqualTo("Leaky faucet"));

            _buildingMemberService.Verify(s => s.GetMyRequests(_user), Times.Once);
        }

        [Test]
        public async Task CreateMaintenanceRequest_ReturnsOk_WithCreatedRequest()
        {
            var requestModel = new MaintenanceRequestModel { Title = "Fix AC", Description = "Air conditioner not working" };
            var createdRequest = new MaintenanceRequest { Id = "1", Title = "Fix AC", Description = "Air conditioner not working" };

            _buildingMemberService.Setup(s => s.CreateMaintenanceRequest(requestModel, _user))
                                  .ReturnsAsync(createdRequest);

            var okResult = await _buildingMemberController.CreateMaintenanceRequest(requestModel) as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult, Is.InstanceOf<OkObjectResult>());

            var results = okResult.Value as MaintenanceRequest;
            Assert.That(results, Is.Not.Null);
            Assert.That(results.Title, Is.EqualTo("Fix AC"));
            Assert.That(results.Description, Is.EqualTo("Air conditioner not working"));

            _buildingMemberService.Verify(s => s.CreateMaintenanceRequest(requestModel, _user), Times.Once);
        }
    }
}
