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
    public class SondeRedoxController : ControllerBase
    {
        private readonly IGenericRepository<SondeRedox> repository;
        private readonly IMapper mapper;

        #region Constructor
        public SondeRedoxController(IGenericRepository<SondeRedox> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }
        #endregion

        #region Read Function
        // GET: api/SondeRedox
        [HttpGet("GetListSondeRedox")]
        public async Task<IEnumerable<SondeRedox>> GetListSondeRedox() =>
             await (new GetListGenericHandler<SondeRedox>(repository)).Handle(new GetListGenericQuery<SondeRedox>(condition: null, includes: null), new CancellationToken());

        // GET: api/SondeRedox/5
        [HttpGet("GetSondeRedox")]
        public async Task<SondeRedox> GetSondeRedox(Guid id) =>
            await (new GetGenericHandler<SondeRedox>(repository)).Handle(new GetGenericQuery<SondeRedox>(condition: x => x.EquipementId.Equals(id), null), new CancellationToken());
        #endregion

        #region Add Function
        // POST: api/SondeRedox
        [HttpPost("PostSondeRedox")]
        public async Task<SondeRedox> PostSondeRedox([FromBody] SondeRedox SondeRedox) =>
            await (new AddGenericHandler<SondeRedox>(repository)).Handle(new AddGenericCommand<SondeRedox>(SondeRedox), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/SondeRedox
        [HttpPut("PutSondeRedox")]
        public async Task<SondeRedox> PutSondeRedox([FromBody] SondeRedox SondeRedox) =>
           await (new PutGenericHandler<SondeRedox>(repository)).Handle(new PutGenericCommand<SondeRedox>(SondeRedox), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/SondeRedox/5
        [HttpDelete("DeleteSondeRedox")]
        public async Task<SondeRedox> DeleteSondeRedox(Guid id) =>
           await (new RemoveGenericHandler<SondeRedox>(repository)).Handle(new RemoveGenericCommand<SondeRedox>(id), new CancellationToken());
        #endregion
    }
}
