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
    public class CapteurDePressionController : ControllerBase
    {

        private readonly IGenericRepository<CapteurDePression> repository;
        private readonly IMapper mapper;

        #region Constructor
        public CapteurDePressionController(IGenericRepository<CapteurDePression> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }
        #endregion

        #region Read Function
        // GET: api/CapteurDePression
        [HttpGet("GetListCapteurDePression")]
        public async Task<IEnumerable<CapteurDePression>> GetListCapteurDePression() =>
             await (new GetListGenericHandler<CapteurDePression>(repository)).Handle(new GetListGenericQuery<CapteurDePression>(condition: null, includes: null), new CancellationToken());

        // GET: api/CapteurDePression/5
        [HttpGet("GetCapteurDePression")]
        public async Task<CapteurDePression> GetCapteurDePression(Guid id) =>
            await (new GetGenericHandler<CapteurDePression>(repository)).Handle(new GetGenericQuery<CapteurDePression>(condition: x => x.EquipementId.Equals(id), null), new CancellationToken());
        #endregion

        #region Add Function
        // POST: api/CapteurDePression
        [HttpPost("PostCapteurDePression")]
        public async Task<CapteurDePression> PostCapteurDePression([FromBody] CapteurDePression CapteurDePression) =>
            await (new AddGenericHandler<CapteurDePression>(repository)).Handle(new AddGenericCommand<CapteurDePression>(CapteurDePression), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/CapteurDePression
        [HttpPut("PutCapteurDePression")]
        public async Task<CapteurDePression> PutCapteurDePression([FromBody] CapteurDePression CapteurDePression) =>
           await (new PutGenericHandler<CapteurDePression>(repository)).Handle(new PutGenericCommand<CapteurDePression>(CapteurDePression), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/CapteurDePression/5
        [HttpDelete("DeleteCapteurDePression")]
        public async Task<CapteurDePression> DeleteCapteurDePression(Guid id) =>
           await (new RemoveGenericHandler<CapteurDePression>(repository)).Handle(new RemoveGenericCommand<CapteurDePression>(id), new CancellationToken());
        #endregion
    }
}

