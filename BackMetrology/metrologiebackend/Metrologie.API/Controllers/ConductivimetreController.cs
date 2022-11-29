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
    public class ConductivimetreController : ControllerBase
    {
        private readonly IGenericRepository<Conductivimetre> repository;
        private readonly IMapper mapper;

        #region Constructor
        public ConductivimetreController(IGenericRepository<Conductivimetre> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }
        #endregion

        #region Read Function
        // GET: api/Conductivimetre
        [HttpGet("GetListConductivimetre")]
        public async Task<IEnumerable<Conductivimetre>> GetListConductivimetre() =>
             await (new GetListGenericHandler<Conductivimetre>(repository)).Handle(new GetListGenericQuery<Conductivimetre>(condition: null, includes: null), new CancellationToken());

        // GET: api/Conductivimetre/5
        [HttpGet("GetConductivimetre")]
        public async Task<Conductivimetre> GetConductivimetre(Guid id) =>
            await (new GetGenericHandler<Conductivimetre>(repository)).Handle(new GetGenericQuery<Conductivimetre>(condition: x => x.EquipementId.Equals(id), null), new CancellationToken());
        #endregion

        #region Add Function
        // POST: api/Conductivimetre
        [HttpPost("PostConductivimetre")]
        public async Task<Conductivimetre> PostConductivimetre([FromBody] Conductivimetre Conductivimetre) =>
            await (new AddGenericHandler<Conductivimetre>(repository)).Handle(new AddGenericCommand<Conductivimetre>(Conductivimetre), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/Conductivimetre
        [HttpPut("PutConductivimetre")]
        public async Task<Conductivimetre> PutConductivimetre([FromBody] Conductivimetre Conductivimetre) =>
           await (new PutGenericHandler<Conductivimetre>(repository)).Handle(new PutGenericCommand<Conductivimetre>(Conductivimetre), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/Conductivimetre/5
        [HttpDelete("DeleteConductivimetre")]
        public async Task<Conductivimetre> DeleteConductivimetre(Guid id) =>
           await (new RemoveGenericHandler<Conductivimetre>(repository)).Handle(new RemoveGenericCommand<Conductivimetre>(id), new CancellationToken());
        #endregion
    }
}
