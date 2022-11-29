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
    public class ThermohygometreController : ControllerBase
    {
        private readonly IGenericRepository<Thermohygometre> repository;
        private readonly IMapper mapper;

        #region Constructor
        public ThermohygometreController(IGenericRepository<Thermohygometre> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }
        #endregion

        #region Read Function
        // GET: api/Thermohygometre
        [HttpGet("GetListThermohygometre")]
        public async Task<IEnumerable<Thermohygometre>> GetListThermohygometre() =>
             await (new GetListGenericHandler<Thermohygometre>(repository)).Handle(new GetListGenericQuery<Thermohygometre>(condition: null, includes: null), new CancellationToken());

        // GET: api/Thermohygometre/5
        [HttpGet("GetThermohygometre")]
        public async Task<Thermohygometre> GetThermohygometre(Guid id) =>
            await (new GetGenericHandler<Thermohygometre>(repository)).Handle(new GetGenericQuery<Thermohygometre>(condition: x => x.EquipementId.Equals(id), null), new CancellationToken());
        #endregion

        #region Add Function
        // POST: api/Thermohygometre
        [HttpPost("PostThermohygometre")]
        public async Task<Thermohygometre> PostThermohygometre([FromBody] Thermohygometre Thermohygometre) =>
            await (new AddGenericHandler<Thermohygometre>(repository)).Handle(new AddGenericCommand<Thermohygometre>(Thermohygometre), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/Thermohygometre
        [HttpPut("PutThermohygometre")]
        public async Task<Thermohygometre> PutThermohygometre([FromBody] Thermohygometre Thermohygometre) =>
           await (new PutGenericHandler<Thermohygometre>(repository)).Handle(new PutGenericCommand<Thermohygometre>(Thermohygometre), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/Thermohygometre/5
        [HttpDelete("DeleteThermohygometre")]
        public async Task<Thermohygometre> DeleteThermohygometre(Guid id) =>
           await (new RemoveGenericHandler<Thermohygometre>(repository)).Handle(new RemoveGenericCommand<Thermohygometre>(id), new CancellationToken());
        #endregion
    }
}
