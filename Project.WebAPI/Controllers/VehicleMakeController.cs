using Microsoft.AspNetCore.Mvc;
using Project.DAL.Contexts;
using Project.Models.Common;
using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace Project.WebAPI.Controllers
{
    public class VehicleMakeController : Controller
    {
        protected IVehicleService Service { get; private set; }

        public VehicleMakeController(IVehicleService service)
        {
            Service = service;
        }

        [System.Web.Http.HttpGet]
        public async Task<ICollection<IVehicleMake>> GetAsync()
        {
            return await Service.GetVehicleMakeAsync();
        }

        [System.Web.Http.HttpGet]
        public async Task<IVehicleMake> GetAsync(int id)
        {
            return await Service.GetVehicleMakeAsync(id);
        }

        [System.Web.Http.HttpPost]
        public async Task<IActionResult> AddAsync(IVehicleMake make)
        {
            await Service.AddVehicleMakeAsync(make);
            return Ok();
        }

        [System.Web.Http.HttpPost]
        public async Task<IActionResult> UpdateAsync(IVehicleMake make)
        {
            await Service.UpdateVehicleMakeAsync(make);
            return Ok();
        }

        [System.Web.Http.HttpPost]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await Service.DeleteVehicleMakeAsync(id);
            return Ok();
        }

    }
}
