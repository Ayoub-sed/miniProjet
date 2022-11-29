using AutoMapper;
using Metrologie.Domain.Commands;
using Metrologie.Domain.Dtos;
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
    public class BainController : ControllerBase
    {

        private readonly IGenericRepository<Bain> repository;
        private readonly IMapper mapper;

        #region Constructor
        public BainController(IGenericRepository<Bain> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }
        #endregion

        #region Read Function
        // GET: api/Bain
        [HttpGet("GetListBain")]
        public async Task<IEnumerable<Bain>> GetListBain() =>
             await (new GetListGenericHandler<Bain>(repository)).Handle(new GetListGenericQuery<Bain>(condition: null, includes: null), new CancellationToken());

     

        // GET: api/Bain/5
        [HttpGet("GetBain")]
        public async Task<Bain> GetBain(Guid id) =>
            await (new GetGenericHandler<Bain>(repository)).Handle(new GetGenericQuery<Bain>(condition: x => x.EquipementId.Equals(id), null), new CancellationToken());
        #endregion

        #region Add Function
        // POST: api/Bain
        [HttpPost("PostBain")]
        public async Task<Bain> PostBain([FromBody] Bain Bain) =>
            await (new AddGenericHandler<Bain>(repository)).Handle(new AddGenericCommand<Bain>(Bain), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/Bain
        [HttpPut("PutBain")]
        public async Task<Bain> PutBain([FromBody] Bain Bain) =>
           await (new PutGenericHandler<Bain>(repository)).Handle(new PutGenericCommand<Bain>(Bain), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/Bain/5
        [HttpDelete("DeleteBain")]
        public async Task<Bain> DeleteBain(Guid id) =>
           await (new RemoveGenericHandler<Bain>(repository)).Handle(new RemoveGenericCommand<Bain>(id), new CancellationToken());
        #endregion
    }
}
