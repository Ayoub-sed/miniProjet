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
    public class ThermometreController : ControllerBase
    {

        private readonly IGenericRepository<Thermometre> repository;
        private readonly IMapper mapper;

        #region Constructor
        public ThermometreController(IGenericRepository<Thermometre> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }
        #endregion

        #region Read Function
        // GET: api/Thermometre
        [HttpGet("GetListThermometre")]
        public async Task<IEnumerable<Thermometre>> GetListThermometre() =>
             await (new GetListGenericHandler<Thermometre>(repository)).Handle(new GetListGenericQuery<Thermometre>(condition: null, includes: null), new CancellationToken());

        // GET: api/Thermometre/5
        [HttpGet("GetThermometre")]
        public async Task<Thermometre> GetThermometre(Guid id) =>
            await (new GetGenericHandler<Thermometre>(repository)).Handle(new GetGenericQuery<Thermometre>(condition: x => x.EquipementId.Equals(id), null), new CancellationToken());
        #endregion

        #region Add Function
        // POST: api/Thermometre
        [HttpPost("PostThermometre")]
        public async Task<Thermometre> PostThermometre([FromBody] Thermometre Thermometre) =>
            await (new AddGenericHandler<Thermometre>(repository)).Handle(new AddGenericCommand<Thermometre>(Thermometre), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/Thermometre
        [HttpPut("PutThermometre")]
        public async Task<Thermometre> PutThermometre([FromBody] Thermometre Thermometre) =>
           await (new PutGenericHandler<Thermometre>(repository)).Handle(new PutGenericCommand<Thermometre>(Thermometre), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/Thermometre/5
        [HttpDelete("DeleteThermometre")]
        public async Task<Thermometre> DeleteThermometre(Guid id) =>
           await (new RemoveGenericHandler<Thermometre>(repository)).Handle(new RemoveGenericCommand<Thermometre>(id), new CancellationToken());
        #endregion
    }
}
