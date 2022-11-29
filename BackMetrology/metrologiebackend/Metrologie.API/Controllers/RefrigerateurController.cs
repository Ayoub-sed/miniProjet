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
    public class RefrigerateurController : ControllerBase
    {

        private readonly IGenericRepository<Refrigerateur> repository;
        private readonly IMapper mapper;

        #region Constructor
        public RefrigerateurController(IGenericRepository<Refrigerateur> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }
        #endregion

        #region Read Function
        // GET: api/Refrigerateur
        [HttpGet("GetListRefrigerateur")]
        public async Task<IEnumerable<Refrigerateur>> GetListRefrigerateur() =>
             await (new GetListGenericHandler<Refrigerateur>(repository)).Handle(new GetListGenericQuery<Refrigerateur>(condition: null, includes: null), new CancellationToken());

        // GET: api/Refrigerateur/5
        [HttpGet("GetRefrigerateur")]
        public async Task<Refrigerateur> GetRefrigerateur(Guid id) =>
            await (new GetGenericHandler<Refrigerateur>(repository)).Handle(new GetGenericQuery<Refrigerateur>(condition: x => x.EquipementId.Equals(id), null), new CancellationToken());
        #endregion

        #region Add Function
        // POST: api/Refrigerateur
        [HttpPost("PostRefrigerateur")]
        public async Task<Refrigerateur> PostRefrigerateur([FromBody] Refrigerateur Refrigerateur) =>
            await (new AddGenericHandler<Refrigerateur>(repository)).Handle(new AddGenericCommand<Refrigerateur>(Refrigerateur), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/Refrigerateur
        [HttpPut("PutRefrigerateur")]
        public async Task<Refrigerateur> PutRefrigerateur([FromBody] Refrigerateur Refrigerateur) =>
           await (new PutGenericHandler<Refrigerateur>(repository)).Handle(new PutGenericCommand<Refrigerateur>(Refrigerateur), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/Refrigerateur/5
        [HttpDelete("DeleteRefrigerateur")]
        public async Task<Refrigerateur> DeleteRefrigerateur(Guid id) =>
           await (new RemoveGenericHandler<Refrigerateur>(repository)).Handle(new RemoveGenericCommand<Refrigerateur>(id), new CancellationToken());
        #endregion
    }
}
