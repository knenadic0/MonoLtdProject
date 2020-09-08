using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using Project.DAL.Contexts;
using Project.DAL.Entities;
using Project.Models;
using Project.Common;
using Project.Service.Common;
using Project.WebAPI.Models;
using Project.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Parser;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace Project.WebAPI.Controllers
{
    [ApiController]
    [Route("Makes")]
    public class VehicleMakeController : ControllerBase
    {
        protected IVehicleMakeService Service { get; private set; }
        protected IMapper Mapper { get; private set; }

        public VehicleMakeController(IVehicleMakeService service, IMapper mapper)
        {
            Service = service;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<ICollection<VehicleMakeModel>> GetMakesAsync(string filterColumn = "", 
            string filterValue = "", int filterOption = 3, string sortBy = "", 
            int sortOrder = 1, int pageSize = 10, int page = 1)
        {
            GetParams getParams = new GetParams()
            {
                PageNumber = page,
                PageSize = pageSize
            };

            FilterParams filterParams = new FilterParams()
            {
                ColumnName = filterColumn,
                FilterValue = filterValue,
                FilterOption = (FilterOptions)filterOption
            };

            SortingParams sortingParams = new SortingParams()
            {
                ColumnName = sortBy,
                SortOrder = (SortOrders)sortOrder
            };

            getParams.FilterParam = new[] { filterParams };
            getParams.SortingParams = new[] { sortingParams };

            return Mapper.Map<List<VehicleMakeModel>>(await Service.GetVehicleMakeAsync(getParams));
        }

        [HttpGet("{id}")]
        public async Task<VehicleMakeModel> GetMakeAsync(int id)
        {
            return Mapper.Map<VehicleMakeModel>(await Service.GetVehicleMakeAsync(id));
        }

        [HttpPost("Add")]
        public async Task<HttpResponseMessage> AddAsync(VehicleMakeModel make)
        {
            try
            {
                await Service.AddVehicleMakeAsync(Mapper.Map<VehicleMake>(make));
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost("Update")]
        public async Task<HttpResponseMessage> UpdateAsync(VehicleMakeModel make)
        {
            try
            {
                await Service.UpdateVehicleMakeAsync(Mapper.Map<VehicleMake>(make));
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
