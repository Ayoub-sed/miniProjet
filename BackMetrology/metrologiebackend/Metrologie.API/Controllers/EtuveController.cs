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
    public class EtuveController : ControllerBase
    {

        private readonly IGenericRepository<Etuve> repository;
        private readonly IMapper mapper;

        #region Constructor
        public EtuveController(IGenericRepository<Etuve> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }
        #endregion

        #region Read Function
        // GET: api/Etuve
        [HttpGet("GetListEtuve")]
        public async Task<IEnumerable<Etuve>> GetListEtuve() =>
             await (new GetListGenericHandler<Etuve>(repository)).Handle(new GetListGenericQuery<Etuve>(condition: null, includes: null), new CancellationToken());

        // GET: api/Etuve/5
        [HttpGet("GetEtuve")]
        public async Task<Etuve> GetEtuve(Guid id) =>
            await (new GetGenericHandler<Etuve>(repository)).Handle(new GetGenericQuery<Etuve>(condition: x => x.EquipementId.Equals(id), null), new CancellationToken());
        #endregion

        #region Add Function
        // POST: api/Etuve
        [HttpPost("PostEtuve")]
        public async Task<Etuve> PostEtuve([FromBody] Etuve Etuve) =>
            await (new AddGenericHandler<Etuve>(repository)).Handle(new AddGenericCommand<Etuve>(Etuve), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/Etuve
        [HttpPut("PutEtuve")]
        public async Task<Etuve> PutEtuve([FromBody] Etuve Etuve) =>
           await (new PutGenericHandler<Etuve>(repository)).Handle(new PutGenericCommand<Etuve>(Etuve), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/Etuve/5
        [HttpDelete("DeleteEtuve")]
        public async Task<Etuve> DeleteEtuve(Guid id) =>
           await (new RemoveGenericHandler<Etuve>(repository)).Handle(new RemoveGenericCommand<Etuve>(id), new CancellationToken());
        #endregion
    }
}
