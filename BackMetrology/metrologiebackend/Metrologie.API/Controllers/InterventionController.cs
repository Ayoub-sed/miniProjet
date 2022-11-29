using AutoMapper;
using Metrologie.Domain.Commands;
using Metrologie.Domain.Dtos;
using Metrologie.Domain.Handlers;
using Metrologie.Domain.Interfaces;
using Metrologie.Domain.Models;
using Metrologie.Domain.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Metrologie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterventionController : ControllerBase
    {
        private readonly IGenericRepository<Intervention> repository;
        private readonly IMapper mapper;

        #region Constructor
        public InterventionController(IGenericRepository<Intervention> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }
        #endregion


        #region Read Function
   
        // GET: api/Intervention/5


        // GET: api/Intervention
        [HttpGet("GetListIntervention")]
        public async Task<IEnumerable<InterventionDto>> GetListIntervention() =>
              (new GetListGenericHandler<Intervention>(repository)).Handle(new GetListGenericQuery<Intervention>(condition: null, includes: null), new CancellationToken())
                .Result.Select(data => mapper.Map<InterventionDto>(data));

        // GET: api/Intervention
        [HttpGet("GetInterventionById")]
        public async Task<IEnumerable<InterventionDto>> GetInterventionById(Guid id) =>
              (new GetListGenericHandler<Intervention>(repository)).Handle(new GetListGenericQuery<Intervention>(condition: x => x.IdIntervention.Equals(id), includes: null), new CancellationToken())
                .Result.Select(data => mapper.Map<InterventionDto>(data));

        // GET: api/Intervention
        [HttpGet("GetInterventionByEquipementID")]
        public async Task<IEnumerable<InterventionDto>> GetInterventionByEquipementID(Guid id) =>
              (new GetListGenericHandler<Intervention>(repository)).Handle(new GetListGenericQuery<Intervention>(condition: x => x.FkEquipement.Equals(id), includes: null), new CancellationToken())
                .Result.Select(data => mapper.Map<InterventionDto>(data));


        // GET: api/Intervention
        [HttpGet("GetInterventionByTypeIntervention")]
        public async Task<IEnumerable<InterventionDto>> GetInterventionByTypeIntervention(Guid id) =>
              (new GetListGenericHandler<Intervention>(repository)).Handle(new GetListGenericQuery<Intervention>(condition: x => x.FktypeIntervention.Equals(id), includes: null), new CancellationToken())
                .Result.Select(data => mapper.Map<InterventionDto>(data));


        #endregion

        #region Add Function
        // POST: api/Intervention
        [HttpPost("PostIntervention")]
        public async Task<Intervention> PostIntervention([FromBody] Intervention Intervention) =>
            await (new AddGenericHandler<Intervention>(repository)).Handle(new AddGenericCommand<Intervention>(Intervention), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/Intervention
        [HttpPut("PutIntervention")]
        public async Task<Intervention> PutIntervention([FromBody] Intervention Intervention) =>
           await (new PutGenericHandler<Intervention>(repository)).Handle(new PutGenericCommand<Intervention>(Intervention), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/Intervention/5
        [HttpDelete("DeleteIntervention")]
        public async Task<Intervention> DeleteIntervention(Guid id) =>
           await (new RemoveGenericHandler<Intervention>(repository)).Handle(new RemoveGenericCommand<Intervention>(id), new CancellationToken());
        #endregion
    }
}
