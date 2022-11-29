using AutoMapper;
using Metrologie.Domain.Commands;
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
    public class EnsacheuseController : ControllerBase
    {
        private readonly IGenericRepository<Ensacheuse> repository;
        private readonly IMapper mapper;

        #region Constructor
        public EnsacheuseController(IGenericRepository<Ensacheuse> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }
        #endregion

        #region Read Function
        // GET: api/Ensacheuse
        [HttpGet("GetListEnsacheuse")]
        public async Task<IEnumerable<Ensacheuse>> GetListEnsacheuse() =>
             await (new GetListGenericHandler<Ensacheuse>(repository)).Handle(new GetListGenericQuery<Ensacheuse>(condition: null, includes: null), new CancellationToken());

        // GET: api/Ensacheuse/5
        [HttpGet("GetEnsacheuse")]
        public async Task<Ensacheuse> GetEnsacheuse(Guid id) =>
            await (new GetGenericHandler<Ensacheuse>(repository)).Handle(new GetGenericQuery<Ensacheuse>(condition: x => x.EquipementId.Equals(id), null), new CancellationToken());
        #endregion

        #region Add Function
        // POST: api/Ensacheuse
        [HttpPost("PostEnsacheuse")]
        public async Task<Ensacheuse> PostEnsacheuse([FromBody] Ensacheuse Ensacheuse) =>
            await (new AddGenericHandler<Ensacheuse>(repository)).Handle(new AddGenericCommand<Ensacheuse>(Ensacheuse), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/Ensacheuse
        [HttpPut("PutEnsacheuse")]
        public async Task<Ensacheuse> PutEnsacheuse([FromBody] Ensacheuse Ensacheuse) =>
           await (new PutGenericHandler<Ensacheuse>(repository)).Handle(new PutGenericCommand<Ensacheuse>(Ensacheuse), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/Ensacheuse/5
        [HttpDelete("DeleteEnsacheuse")]
        public async Task<Ensacheuse> DeleteEnsacheuse(Guid id) =>
           await (new RemoveGenericHandler<Ensacheuse>(repository)).Handle(new RemoveGenericCommand<Ensacheuse>(id), new CancellationToken());
        #endregion
    }
}
