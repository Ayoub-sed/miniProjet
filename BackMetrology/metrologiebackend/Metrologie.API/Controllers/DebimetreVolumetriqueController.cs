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
    public class DebimetreVolumetriqueController : ControllerBase
    {
        private readonly IGenericRepository<DebimetreVolumetrique> repository;
        private readonly IMapper mapper;

        #region Constructor
        public DebimetreVolumetriqueController(IGenericRepository<DebimetreVolumetrique> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }
        #endregion

        #region Read Function
        // GET: api/DebimetreVolumetrique
        [HttpGet("GetListDebimetreVolumetrique")]
        public async Task<IEnumerable<DebimetreVolumetrique>> GetListDebimetreVolumetrique() =>
             await (new GetListGenericHandler<DebimetreVolumetrique>(repository)).Handle(new GetListGenericQuery<DebimetreVolumetrique>(condition: null, includes: null), new CancellationToken());

        // GET: api/DebimetreVolumetrique/5
        [HttpGet("GetDebimetreVolumetrique")]
        public async Task<DebimetreVolumetrique> GetDebimetreVolumetrique(Guid id) =>
            await (new GetGenericHandler<DebimetreVolumetrique>(repository)).Handle(new GetGenericQuery<DebimetreVolumetrique>(condition: x => x.EquipementId.Equals(id), null), new CancellationToken());
        #endregion

        #region Add Function
        // POST: api/DebimetreVolumetrique
        [HttpPost("PostDebimetreVolumetrique")]
        public async Task<DebimetreVolumetrique> PostDebimetreVolumetrique([FromBody] DebimetreVolumetrique DebimetreVolumetrique) =>
            await (new AddGenericHandler<DebimetreVolumetrique>(repository)).Handle(new AddGenericCommand<DebimetreVolumetrique>(DebimetreVolumetrique), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/DebimetreVolumetrique
        [HttpPut("PutDebimetreVolumetrique")]
        public async Task<DebimetreVolumetrique> PutDebimetreVolumetrique([FromBody] DebimetreVolumetrique DebimetreVolumetrique) =>
           await (new PutGenericHandler<DebimetreVolumetrique>(repository)).Handle(new PutGenericCommand<DebimetreVolumetrique>(DebimetreVolumetrique), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/DebimetreVolumetrique/5
        [HttpDelete("DeleteDebimetreVolumetrique")]
        public async Task<DebimetreVolumetrique> DeleteDebimetreVolumetrique(Guid id) =>
           await (new RemoveGenericHandler<DebimetreVolumetrique>(repository)).Handle(new RemoveGenericCommand<DebimetreVolumetrique>(id), new CancellationToken());
        #endregion
    }
}
