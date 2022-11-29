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
    public class PontsBasculeElectroniqueController : ControllerBase
    {
        private readonly IGenericRepository<PontsBasculeElectronique> repository;
        private readonly IMapper mapper;

        #region Constructor
        public PontsBasculeElectroniqueController(IGenericRepository<PontsBasculeElectronique> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }
        #endregion

        #region Read Function
        // GET: api/PontsBasculeElectronique
        [HttpGet("GetListPontsBasculeElectronique")]
        public async Task<IEnumerable<PontsBasculeElectronique>> GetListPontsBasculeElectronique() =>
             await (new GetListGenericHandler<PontsBasculeElectronique>(repository)).Handle(new GetListGenericQuery<PontsBasculeElectronique>(condition: null, includes: null), new CancellationToken());

        // GET: api/PontsBasculeElectronique/5
        [HttpGet("GetPontsBasculeElectronique")]
        public async Task<PontsBasculeElectronique> GetPontsBasculeElectronique(Guid id) =>
            await (new GetGenericHandler<PontsBasculeElectronique>(repository)).Handle(new GetGenericQuery<PontsBasculeElectronique>(condition: x => x.EquipementId.Equals(id), null), new CancellationToken());
        #endregion

        #region Add Function
        // POST: api/PontsBasculeElectronique
        [HttpPost("PostPontsBasculeElectronique")]
        public async Task<PontsBasculeElectronique> PostPontsBasculeElectronique([FromBody] PontsBasculeElectronique PontsBasculeElectronique) =>
            await (new AddGenericHandler<PontsBasculeElectronique>(repository)).Handle(new AddGenericCommand<PontsBasculeElectronique>(PontsBasculeElectronique), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/PontsBasculeElectronique
        [HttpPut("PutPontsBasculeElectronique")]
        public async Task<PontsBasculeElectronique> PutPontsBasculeElectronique([FromBody] PontsBasculeElectronique PontsBasculeElectronique) =>
           await (new PutGenericHandler<PontsBasculeElectronique>(repository)).Handle(new PutGenericCommand<PontsBasculeElectronique>(PontsBasculeElectronique), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/PontsBasculeElectronique/5
        [HttpDelete("DeletePontsBasculeElectronique")]
        public async Task<PontsBasculeElectronique> DeletePontsBasculeElectronique(Guid id) =>
           await (new RemoveGenericHandler<PontsBasculeElectronique>(repository)).Handle(new RemoveGenericCommand<PontsBasculeElectronique>(id), new CancellationToken());
        #endregion
    }
}
