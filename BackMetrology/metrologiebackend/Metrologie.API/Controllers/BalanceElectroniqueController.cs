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
    public class BalanceElectroniqueController : ControllerBase
    {

        private readonly IGenericRepository<BalanceElectronique> repository;
        private readonly IMapper mapper;

        #region Constructor
        public BalanceElectroniqueController(IGenericRepository<BalanceElectronique> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }
        #endregion

        #region Read Function
        // GET: api/BalanceElectronique
        [HttpGet("GetListBalanceElectronique")]
        public async Task<IEnumerable<BalanceElectronique>> GetListBalanceElectronique() =>
             await (new GetListGenericHandler<BalanceElectronique>(repository)).Handle(new GetListGenericQuery<BalanceElectronique>(condition: null, includes: null), new CancellationToken());

        // GET: api/BalanceElectronique/5
        [HttpGet("GetBalanceElectronique")]
        public async Task<BalanceElectronique> GetBalanceElectronique(Guid id) =>
            await (new GetGenericHandler<BalanceElectronique>(repository)).Handle(new GetGenericQuery<BalanceElectronique>(condition: x => x.EquipementId.Equals(id), null), new CancellationToken());
        #endregion

        #region Add Function
        // POST: api/BalanceElectronique
        [HttpPost("PostBalanceElectronique")]
        public async Task<BalanceElectronique> PostBalanceElectronique([FromBody] BalanceElectronique BalanceElectronique)
        {
           return await (new AddGenericHandler<BalanceElectronique>(repository)).Handle(new AddGenericCommand<BalanceElectronique>(BalanceElectronique), new CancellationToken());
        }
            #endregion

            #region Update Funtion
            // PUT: api/BalanceElectronique
            [HttpPut("PutBalanceElectronique")]
        public async Task<BalanceElectronique> PutBalanceElectronique([FromBody] BalanceElectronique BalanceElectronique) =>
           await (new PutGenericHandler<BalanceElectronique>(repository)).Handle(new PutGenericCommand<BalanceElectronique>(BalanceElectronique), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/BalanceElectronique/5
        [HttpDelete("DeleteBalanceElectronique")]
        public async Task<BalanceElectronique> DeleteBalanceElectronique(Guid id) =>
           await (new RemoveGenericHandler<BalanceElectronique>(repository)).Handle(new RemoveGenericCommand<BalanceElectronique>(id), new CancellationToken());
        #endregion
    }
}
