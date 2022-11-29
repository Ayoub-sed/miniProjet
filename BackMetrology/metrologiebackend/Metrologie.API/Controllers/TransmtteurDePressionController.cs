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
    public class TransmtteurDePressionController : ControllerBase
    {
        private readonly IGenericRepository<TransmtteurDePression> repository;
        private readonly IMapper mapper;

        #region Constructor
        public TransmtteurDePressionController(IGenericRepository<TransmtteurDePression> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }
        #endregion

        #region Read Function
        // GET: api/TransmtteurDePression
        [HttpGet("GetListTransmtteurDePression")]
        public async Task<IEnumerable<TransmtteurDePression>> GetListTransmtteurDePression() =>
             await (new GetListGenericHandler<TransmtteurDePression>(repository)).Handle(new GetListGenericQuery<TransmtteurDePression>(condition: null, includes: null), new CancellationToken());

        // GET: api/TransmtteurDePression/5
        [HttpGet("GetTransmtteurDePression")]
        public async Task<TransmtteurDePression> GetTransmtteurDePression(Guid id) =>
            await (new GetGenericHandler<TransmtteurDePression>(repository)).Handle(new GetGenericQuery<TransmtteurDePression>(condition: x => x.EquipementId.Equals(id), null), new CancellationToken());
        #endregion

        #region Add Function
        // POST: api/TransmtteurDePression
        [HttpPost("PostTransmtteurDePression")]
        public async Task<TransmtteurDePression> PostTransmtteurDePression([FromBody] TransmtteurDePression TransmtteurDePression) =>
            await (new AddGenericHandler<TransmtteurDePression>(repository)).Handle(new AddGenericCommand<TransmtteurDePression>(TransmtteurDePression), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/TransmtteurDePression
        [HttpPut("PutTransmtteurDePression")]
        public async Task<TransmtteurDePression> PutTransmtteurDePression([FromBody] TransmtteurDePression TransmtteurDePression) =>
           await (new PutGenericHandler<TransmtteurDePression>(repository)).Handle(new PutGenericCommand<TransmtteurDePression>(TransmtteurDePression), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/TransmtteurDePression/5
        [HttpDelete("DeleteTransmtteurDePression")]
        public async Task<TransmtteurDePression> DeleteTransmtteurDePression(Guid id) =>
           await (new RemoveGenericHandler<TransmtteurDePression>(repository)).Handle(new RemoveGenericCommand<TransmtteurDePression>(id), new CancellationToken());
        #endregion
    }
}
