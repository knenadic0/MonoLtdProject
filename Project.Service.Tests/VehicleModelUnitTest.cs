using Project.DAL;
using Project.Repository;
using Project.Service;
using Project.Service.Common;
using System;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using Project.Models.Common;

namespace Project.Service.Tests
{
    public class VehicleModelUnitTest
    {
        private readonly VehicleMakeService service;

        //public VehicleModelUnitTest()
        //{
        //    //this.service = new VehicleMakeService(new VehicleMakeRepository(new TestContext()));
        //}

        //[Fact]
        //public async System.Threading.Tasks.Task GetModelsAsync()
        //{
        //    //ICollection<IVehicleModel> models = await service.GetVehicleModelAsync();

        //    models.Should().HaveCount(4);
        //}
    }
}
