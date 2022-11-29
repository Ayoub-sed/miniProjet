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
    public class TunnelDeRefroidissementController : ControllerBase
    {

        private readonly IGenericRepository<TunnelDeRefroidissement> repository;
        private readonly IMapper mapper;

        #region Constructor
        public TunnelDeRefroidissementController(IGenericRepository<TunnelDeRefroidissement> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }
        #endregion

        #region Read Function
        // GET: api/TunnelDeRefroidissement
        [HttpGet("GetListTunnelDeRefroidissement")]
        public async Task<IEnumerable<TunnelDeRefroidissement>> GetListTunnelDeRefroidissement() =>
             await (new GetListGenericHandler<TunnelDeRefroidissement>(repository)).Handle(new GetListGenericQuery<TunnelDeRefroidissement>(condition: null, includes: null), new CancellationToken());

        // GET: api/TunnelDeRefroidissement/5
        [HttpGet("GetTunnelDeRefroidissement")]
        public async Task<TunnelDeRefroidissement> GetTunnelDeRefroidissement(Guid id) =>
            await (new GetGenericHandler<TunnelDeRefroidissement>(repository)).Handle(new GetGenericQuery<TunnelDeRefroidissement>(condition: x => x.EquipementId.Equals(id), null), new CancellationToken());
        #endregion

        #region Add Function
        // POST: api/TunnelDeRefroidissement
        [HttpPost("PostTunnelDeRefroidissement")]
        public async Task<TunnelDeRefroidissement> PostTunnelDeRefroidissement([FromBody] TunnelDeRefroidissement TunnelDeRefroidissement) =>
            await (new AddGenericHandler<TunnelDeRefroidissement>(repository)).Handle(new AddGenericCommand<TunnelDeRefroidissement>(TunnelDeRefroidissement), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/TunnelDeRefroidissement
        [HttpPut("PutTunnelDeRefroidissement")]
        public async Task<TunnelDeRefroidissement> PutTunnelDeRefroidissement([FromBody] TunnelDeRefroidissement TunnelDeRefroidissement) =>
           await (new PutGenericHandler<TunnelDeRefroidissement>(repository)).Handle(new PutGenericCommand<TunnelDeRefroidissement>(TunnelDeRefroidissement), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/TunnelDeRefroidissement/5
        [HttpDelete("DeleteTunnelDeRefroidissement")]
        public async Task<TunnelDeRefroidissement> DeleteTunnelDeRefroidissement(Guid id) =>
           await (new RemoveGenericHandler<TunnelDeRefroidissement>(repository)).Handle(new RemoveGenericCommand<TunnelDeRefroidissement>(id), new CancellationToken());
        #endregion
    }
}
