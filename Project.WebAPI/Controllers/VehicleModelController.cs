using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Models.Common;
using Project.Service.Common;
using Project.WebAPI.Models;
using Project.WebAPI.Profiles;
using Project.WebAPI.ViewModels;

namespace Project.WebAPI.Controllers
{
    [ApiController]
    [Route("Models")]
    public class VehicleModelController : ControllerBase
    {
        protected IVehicleModelService Service { get; private set; }
        protected IMapper Mapper { get; private set; }

        public VehicleModelController(IVehicleModelService service, IMapper mapper)
        {
            Service = service;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<ICollection<VehicleModelModel>> GetModelsAsync()
        {
            return Mapper.Map<List<VehicleModelModel>>(await Service.GetVehicleModelAsync());
        }

        [HttpGet("{id}")]
        public async Task<VehicleModelModel> GetModelAsync(int id)
        {
            return Mapper.Map<VehicleModelModel>(await Service.GetVehicleModelAsync(id));
        }

        [HttpPost("Add")]
        public async Task<HttpResponseMessage> AddAsync(VehicleModelModel model)
        {
            try
            {
                await Service.AddVehicleModelAsync(Mapper.Map<VehicleModel>(model));
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost("Update")]
        public async Task<HttpResponseMessage> UpdateAsync(VehicleModelModel model)
        {
            try
            {
                await Service.UpdateVehicleModelAsync(Mapper.Map<VehicleModel>(model));
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
