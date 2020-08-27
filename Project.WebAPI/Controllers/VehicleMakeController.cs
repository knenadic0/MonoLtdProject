using Microsoft.AspNetCore.Mvc;
using Project.DAL.Contexts;
using Project.Models;
using Project.Models.Common;
using Project.Service.Common;
using Project.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace Project.WebAPI.Controllers
{
    [ApiController]
    [Route("Makes")]
    public class VehicleMakeController : ControllerBase
    {
        protected IVehicleService Service { get; private set; }

        public VehicleMakeController(IVehicleService service)
        {
            Service = service;
        }

        [HttpGet]
        public async Task<ICollection<IVehicleMake>> GetMakesAsync()
        {
            return await Service.GetVehicleMakeAsync();
        }

        [HttpGet("{id}")]
        public async Task<IVehicleMake> GetMakeAsync(int id)
        {
            return await Service.GetVehicleMakeAsync(id);
        }

        [HttpPost("Add")]
        public async Task<HttpResponseMessage> AddAsync(VehicleMake make)
        {
            try
            {
                await Service.AddVehicleMakeAsync(make);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost("Update")]
        public async Task<HttpResponseMessage> UpdateAsync(VehicleMake make)
        {
            try
            {
                await Service.UpdateVehicleMakeAsync(make);
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
                await Service.DeleteVehicleMakeAsync(id.Id);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}
