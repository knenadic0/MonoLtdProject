using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Common;
using Project.Common.Filtering;
using Project.Common.Paging;
using Project.Common.Sorting;
using Project.DAL.Entities;
using Project.Models;
using Project.Service.Common;
using Project.WebAPI.Models;
using Project.WebAPI.ViewModels;

namespace Project.WebAPI.Controllers
{
    [ApiController]
    [Route("Models")]
    public class VehicleModelController : ControllerBase
    {
        protected IVehicleModelService Service { get; private set; }
        protected IMapper Mapper { get; private set; }
        public IFilter Filter { get; private set; }
        public ISort Sort { get; private set; }
        public IPage Page { get; private set; }

        public VehicleModelController(IVehicleModelService service, IMapper mapper, IFilter filter, ISort sort, IPage page)
        {
            Service = service;
            Mapper = mapper;
            Filter = filter;
            Sort = sort;
            Page = page;
        }

        [HttpGet]
        public async Task<ICollection<VehicleModelModel>> GetModelsAsync(string filterColumn = "",
            string filterValue = "", int filterOption = 3, string sortBy = "",
            int sortOrder = 1, int pageSize = 10, int page = 1)
        {
            GetParams<VehicleModel> getParams = new GetParams<VehicleModel>()
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
            getParams.SortingParam = new[] { sortingParams };

            getParams.Filter = Filter;
            getParams.Sort = Sort;
            getParams.Page = Page;

            return Mapper.Map<List<VehicleModelModel>>(await Service.GetVehicleModelAsync(getParams));
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
