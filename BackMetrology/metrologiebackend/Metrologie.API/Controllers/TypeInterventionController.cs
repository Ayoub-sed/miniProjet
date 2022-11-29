using AutoMapper;
using Metrologie.Domain.Commands;
using Metrologie.Domain.Handlers;
using Metrologie.Domain.Interfaces;
using Metrologie.Domain.Models;
using Metrologie.Domain.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Metrologie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeInterventionController : ControllerBase
    {
        private readonly IGenericRepository<TypeIntervention> repository;
        private readonly IMapper mapper;

        #region Constructor
        public TypeInterventionController(IGenericRepository<TypeIntervention> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }
        #endregion

        #region Read Function
        // GET: api/TypeIntervention
        [HttpGet("GetListTypeIntervention")]
        public async Task<IEnumerable<TypeIntervention>> GetListTypeIntervention() =>
             await (new GetListGenericHandler<TypeIntervention>(repository)).Handle(new GetListGenericQuery<TypeIntervention>(condition: null, includes: null), new CancellationToken());

        // GET: api/TypeIntervention/5
        [HttpGet("GetTypeIntervention")]
        public async Task<TypeIntervention> GetTypeIntervention(Guid id) =>
            await (new GetGenericHandler<TypeIntervention>(repository)).Handle(new GetGenericQuery<TypeIntervention>(condition: x => x.TypeInterventionId.Equals(id), null), new CancellationToken());
        #endregion

        #region Add Function
        // POST: api/TypeIntervention
        [HttpPost("PostTypeIntervention")]
        public async Task<TypeIntervention> PostTypeIntervention([FromBody] TypeIntervention TypeIntervention) =>
            await (new AddGenericHandler<TypeIntervention>(repository)).Handle(new AddGenericCommand<TypeIntervention>(TypeIntervention), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/TypeIntervention
        [HttpPut("PutTypeIntervention")]
        public async Task<TypeIntervention> PutTypeIntervention([FromBody] TypeIntervention TypeIntervention) =>
           await (new PutGenericHandler<TypeIntervention>(repository)).Handle(new PutGenericCommand<TypeIntervention>(TypeIntervention), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/TypeIntervention/5
        [HttpDelete("DeleteTypeIntervention")]
        public async Task<TypeIntervention> DeleteTypeIntervention(Guid id) =>
           await (new RemoveGenericHandler<TypeIntervention>(repository)).Handle(new RemoveGenericCommand<TypeIntervention>(id), new CancellationToken());
        #endregion
    }
} 
