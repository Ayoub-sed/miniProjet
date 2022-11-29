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
    public class DebimetreMassiqueController : ControllerBase
    {
        private readonly IGenericRepository<DebimetreMassique> repository;
        private readonly IMapper mapper;

        #region Constructor
        public DebimetreMassiqueController(IGenericRepository<DebimetreMassique> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }
        #endregion

        #region Read Function
        // GET: api/DebimetreMassique
        [HttpGet("GetListDebimetreMassique")]
        public async Task<IEnumerable<DebimetreMassique>> GetListDebimetreMassique() =>
             await (new GetListGenericHandler<DebimetreMassique>(repository)).Handle(new GetListGenericQuery<DebimetreMassique>(condition: null, includes: null), new CancellationToken());

        // GET: api/DebimetreMassique/5
        [HttpGet("GetDebimetreMassique")]
        public async Task<DebimetreMassique> GetDebimetreMassique(Guid id) =>
            await (new GetGenericHandler<DebimetreMassique>(repository)).Handle(new GetGenericQuery<DebimetreMassique>(condition: x => x.EquipementId.Equals(id), null), new CancellationToken());
        #endregion

        #region Add Function
        // POST: api/DebimetreMassique
        [HttpPost("PostDebimetreMassique")]
        public async Task<DebimetreMassique> PostDebimetreMassique([FromBody] DebimetreMassique DebimetreMassique) =>
            await (new AddGenericHandler<DebimetreMassique>(repository)).Handle(new AddGenericCommand<DebimetreMassique>(DebimetreMassique), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/DebimetreMassique
        [HttpPut("PutDebimetreMassique")]
        public async Task<DebimetreMassique> PutDebimetreMassique([FromBody] DebimetreMassique DebimetreMassique) =>
           await (new PutGenericHandler<DebimetreMassique>(repository)).Handle(new PutGenericCommand<DebimetreMassique>(DebimetreMassique), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/DebimetreMassique/5
        [HttpDelete("DeleteDebimetreMassique")]
        public async Task<DebimetreMassique> DeleteDebimetreMassique(Guid id) =>
           await (new RemoveGenericHandler<DebimetreMassique>(repository)).Handle(new RemoveGenericCommand<DebimetreMassique>(id), new CancellationToken());
        #endregion
    }
}
