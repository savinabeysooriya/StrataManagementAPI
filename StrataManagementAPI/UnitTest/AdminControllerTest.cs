using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using StrataManagementAPI.Controllers;
using StrataManagementAPI.DataAccess;
using StrataManagementAPI.Models;

namespace StrataManagementAPI.UnitTest
{
    [TestFixture]
    public class AdminControllerTest
    {
        private Mock<IAdminService> _adminService;
        private AdminController _adminController;

        [SetUp]
        public void Setup()
        {
            _adminService = new Mock<IAdminService>();
            _adminController = new AdminController(_adminService.Object);
        }

        [Test]
        public async Task GetBuildings_ReturnsOkResult_WithListOfBuildings()
        {
            var buildings = new List<Building> { new Building { Id = "1", Name = "Building A" } };
            _adminService.Setup(s => s.GetBuildings()).ReturnsAsync(buildings);

            var okResult = await _adminController.GetBuildings() as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult, Is.InstanceOf<OkObjectResult>());

            var results = okResult.Value as List<Building>; 
            Assert.That(results.Count, Is.EqualTo(1));
            Assert.That(results.First().Name, Is.EqualTo("Building A"));

            _adminService.Verify(s => s.GetBuildings(), Times.Once);
        }

        [Test]
        public async Task GetOwners_ReturnsOkResult_WithListOfOwners()
        {
            var owners = new List<Owner> { new Owner { Id = "1", Name = "John Doe" } };
            _adminService.Setup(s => s.GetOwners()).ReturnsAsync(owners);

            var okResult = await _adminController.GetOwners() as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult, Is.InstanceOf<OkObjectResult>());

            var results = okResult.Value as List<Owner>;
            Assert.That(results.Count, Is.EqualTo(1));
            Assert.That(results.First().Name, Is.EqualTo("John Doe"));

            _adminService.Verify(s => s.GetOwners(), Times.Once);
        }

        [Test]
        public async Task GetTenants_ReturnsOkResult_WithListOfTenants()
        {
            var tenants = new List<Tenant> { new Tenant { Id = "1", Name = "Test Tenant" } };
            _adminService.Setup(s => s.GetTenants()).ReturnsAsync(tenants);

            var okResult = await _adminController.GetTenants() as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult, Is.InstanceOf<OkObjectResult>());

            var results = okResult.Value as List<Tenant>;
            Assert.That(results.Count, Is.EqualTo(1));
            Assert.That(results.First().Name, Is.EqualTo("Test Tenant"));

            _adminService.Verify(s => s.GetTenants(), Times.Once);
        }

        [Test]
        public async Task GetMaintenanceRequests_ReturnsOkResult_WithListOfRequests()
        {
            var requests = new List<MaintenanceRequest> { new MaintenanceRequest { Id = "1", Description = "Leaky faucet" } };
            _adminService.Setup(s => s.GetMaintenanceRequests()).ReturnsAsync(requests);

            var okResult = await _adminController.GetMaintenanceRequests() as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult, Is.InstanceOf<OkObjectResult>());

            var results = okResult.Value as List<MaintenanceRequest>;
            Assert.That(results.Count, Is.EqualTo(1));
            Assert.That(results.First().Description, Is.EqualTo("Leaky faucet"));

            _adminService.Verify(s => s.GetMaintenanceRequests(), Times.Once);
        }
    }
}

