using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Models.Common;
using Project.Service.Common;
using Project.WebAPI.ViewModels;

namespace Project.WebAPI.Controllers
{
    [ApiController]
    [Route("Models")]
    public class VehicleModelController : ControllerBase
    {
        protected IVehicleService Service { get; private set; }

        public VehicleModelController(IVehicleService service)
        {
            Service = service;
        }

        [HttpGet]
        public async Task<ICollection<IVehicleModel>> GetModelsAsync()
        {
            var hue = await Service.GetVehicleModelAsync();
            return hue;
        }

        [HttpGet("{id}")]
        public async Task<IVehicleModel> GetModelAsync(int id)
        {
            return await Service.GetVehicleModelAsync(id);
        }

        [HttpPost("Add")]
        public async Task<HttpResponseMessage> AddAsync(VehicleModel model)
        {
            try
            {
                await Service.AddVehicleModelAsync(model);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost("Update")]
        public async Task<HttpResponseMessage> UpdateAsync(VehicleModel model)
        {
            try
            {
                await Service.UpdateVehicleModelAsync(model);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost("Delete")]
        public async Task<HttpResponseMessage> DeleteAsync(DeleteById id)
        {
            try
            {
                await Service.DeleteVehicleModelAsync(id.Id);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
