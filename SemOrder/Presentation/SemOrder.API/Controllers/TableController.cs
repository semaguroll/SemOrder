using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SemOrder.API.Controllers.Base;
using SemOrder.Common.DTOs.Table;
using SemOrder.Common.Models;
using SemOrder.Model.Entities;
using SemOrder.Service.Repository.Table;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SemOrder.API.Controllers
{
    [Route("table")]
    public class TableController : BaseApiController<TableController>
    {
        private readonly ITableRepository _tableRepo;
        private readonly IMapper _mapper;
        public TableController(ITableRepository tableRepo, IMapper mapper)
        {
            _tableRepo = tableRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<TableRequest>>>> GetTables()
        {
            var tables = await _tableRepo.TableNoTracking.ToListAsync();
            var tableResponse = _mapper.Map<List<TableRequest>>(tables);
            if (tableResponse.Count > 0)
                return new WebApiResponse<List<TableRequest>>(true, "Success", tableResponse);
            return new WebApiResponse<List<TableRequest>>(false, "Error");
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<TableRequest>>> GetTable(Guid id)
        {
            var table = await _tableRepo.GetById(id);
            var tableResponse = _mapper.Map<TableRequest>(table);
            if (tableResponse != null)
                return new WebApiResponse<TableRequest>(true, "Success", tableResponse);
            return new WebApiResponse<TableRequest>(false, "Error");
        }
        [HttpPost]
        public async Task<ActionResult<WebApiResponse<TableRequest>>> AddTable(TableRequest request)
        {
            var table = _mapper.Map<Table>(request);
            var addTable = await _tableRepo.Add(table);
            if (addTable != null)
            {
                var tableResponse = _mapper.Map<TableRequest>(addTable);
                return new WebApiResponse<TableRequest>(true, "Success", tableResponse);
            }
            else
                return new WebApiResponse<TableRequest>(false, "Error");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<TableRequest>>> UpdateTable(Guid id, TableRequest request)
        {
            if (id != request.ID)
                return BadRequest();
            try
            {
                var table = await _tableRepo.GetById(id);
                _mapper.Map(request, table);

                var updateTable = await _tableRepo.Update(table);
                if (updateTable != null)
                {
                    var tableResponse = _mapper.Map<TableRequest>(updateTable);
                    return new WebApiResponse<TableRequest>(true, "Success", tableResponse);
                }
                else
                    return new WebApiResponse<TableRequest>(false, "Error");
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> DeleteTable(Guid id)
        {
            var table = await _tableRepo.GetById(id);
            var deletedTable = await _tableRepo.Remove(table);
            if (deletedTable)
                return new WebApiResponse<bool>(true, "Success");
            return new WebApiResponse<bool>(false, "Error");
        }
        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> ActivateTable(Guid id)
        {
            var activeTable = await _tableRepo.Activate(id);
            if (activeTable)
                return new WebApiResponse<bool>(true, "Success", true);
            return new WebApiResponse<bool>(false, "Error");
        }
        [HttpGet("inactivate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> InactivateTable(Guid id)
        {
            var activeTable = await _tableRepo.Inactivate(id);
            if (activeTable)
                return new WebApiResponse<bool>(true, "Success", true);
            return new WebApiResponse<bool>(false, "Error");
        }
        [HttpGet("getactive")]
        public async Task<ActionResult<WebApiResponse<List<TableRequest>>>> GetActiveTables()
        {
            var activeTables = await _tableRepo.GetActive().ToListAsync();
            var tableResponse = _mapper.Map<List<TableRequest>>(activeTables);
            if (tableResponse.Count > 0)
                return new WebApiResponse<List<TableRequest>>(true, "Success", tableResponse);
            return new WebApiResponse<List<TableRequest>>(false, "Error");
        }
    }
}
