using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Models.Common;
using Project.Service.Common;

namespace Project.WebAPI.Controllers
{
    public class VehicleModelController : Controller
    {
        protected IVehicleService Service { get; private set; }

        public VehicleModelController(IVehicleService service)
        {
            Service = service;
        }

        [System.Web.Http.HttpGet]
        public async Task<ICollection<IVehicleModel>> GetAsync()
        {
            return await Service.GetVehicleModelAsync();
        }

        [System.Web.Http.HttpGet]
        public async Task<IVehicleModel> GetAsync(int id)
        {
            return await Service.GetVehicleModelAsync(id);
        }

        [System.Web.Http.HttpPost]
        public async Task<IActionResult> AddAsync(IVehicleModel model)
        {
            await Service.AddVehicleModelAsync(model);
            return Ok();
        }

        [System.Web.Http.HttpPost]
        public async Task<IActionResult> UpdateAsync(IVehicleModel model)
        {
            await Service.UpdateVehicleModelAsync(model);
            return Ok();
        }

        [System.Web.Http.HttpPost]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await Service.DeleteVehicleModelAsync(id);
            return Ok();
        }
    }
}
