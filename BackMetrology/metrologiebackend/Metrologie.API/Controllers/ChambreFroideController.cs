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
    public class ChambreFroideController : ControllerBase
    {
        private readonly IGenericRepository<ChambreFroide> repository;
        private readonly IMapper mapper;

        #region Constructor
        public ChambreFroideController(IGenericRepository<ChambreFroide > repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }
        #endregion

        #region Read Function
        // GET: api/ChambreFroide 
        [HttpGet("GetListChambreFroide")]
        public async Task<IEnumerable<ChambreFroide >> GetListChambreFroide () =>
             await (new GetListGenericHandler<ChambreFroide >(repository)).Handle(new GetListGenericQuery<ChambreFroide >(condition: null, includes: null), new CancellationToken());

        // GET: api/ChambreFroide /5
        [HttpGet("GetChambreFroide")]
        public async Task<ChambreFroide > GetChambreFroide (Guid id) =>
            await (new GetGenericHandler<ChambreFroide >(repository)).Handle(new GetGenericQuery<ChambreFroide >(condition: x => x.EquipementId.Equals(id), null), new CancellationToken());
        #endregion

        #region Add Function
        // POST: api/ChambreFroide 
        [HttpPost("PostChambreFroide")]
        public async Task<ChambreFroide > PostChambreFroide ([FromBody] ChambreFroide  ChambreFroide ) =>
            await (new AddGenericHandler<ChambreFroide >(repository)).Handle(new AddGenericCommand<ChambreFroide >(ChambreFroide ), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/ChambreFroide 
        [HttpPut("PutChambreFroide")]
        public async Task<ChambreFroide > PutChambreFroide ([FromBody] ChambreFroide  ChambreFroide ) =>
           await (new PutGenericHandler<ChambreFroide >(repository)).Handle(new PutGenericCommand<ChambreFroide >(ChambreFroide ), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/ChambreFroide /5
        [HttpDelete("DeleteChambreFroide")]
        public async Task<ChambreFroide > DeleteChambreFroide (Guid id) =>
           await (new RemoveGenericHandler<ChambreFroide >(repository)).Handle(new RemoveGenericCommand<ChambreFroide >(id), new CancellationToken());
        #endregion

    }
}
