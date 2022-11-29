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
    public class ManometreDePressionController : ControllerBase
    {
        private readonly IGenericRepository<ManometreDePression> repository;
        private readonly IMapper mapper;

        #region Constructor
        public ManometreDePressionController(IGenericRepository<ManometreDePression> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }
        #endregion

        #region Read Function
        // GET: api/ManometreDePression
        [HttpGet("GetListManometreDePression")]
        public async Task<IEnumerable<ManometreDePression>> GetListManometreDePression() =>
             await (new GetListGenericHandler<ManometreDePression>(repository)).Handle(new GetListGenericQuery<ManometreDePression>(condition: null, includes: null), new CancellationToken());

        // GET: api/ManometreDePression/5
        [HttpGet("GetManometreDePression")]
        public async Task<ManometreDePression> GetManometreDePression(Guid id) =>
            await (new GetGenericHandler<ManometreDePression>(repository)).Handle(new GetGenericQuery<ManometreDePression>(condition: x => x.EquipementId.Equals(id), null), new CancellationToken());
        #endregion

        #region Add Function
        // POST: api/ManometreDePression
        [HttpPost("PostManometreDePression")]
        public async Task<ManometreDePression> PostManometreDePression([FromBody] ManometreDePression ManometreDePression) =>
            await (new AddGenericHandler<ManometreDePression>(repository)).Handle(new AddGenericCommand<ManometreDePression>(ManometreDePression), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/ManometreDePression
        [HttpPut("PutManometreDePression")]
        public async Task<ManometreDePression> PutManometreDePression([FromBody] ManometreDePression ManometreDePression) =>
           await (new PutGenericHandler<ManometreDePression>(repository)).Handle(new PutGenericCommand<ManometreDePression>(ManometreDePression), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/ManometreDePression/5
        [HttpDelete("DeleteManometreDePression")]
        public async Task<ManometreDePression> DeleteManometreDePression(Guid id) =>
           await (new RemoveGenericHandler<ManometreDePression>(repository)).Handle(new RemoveGenericCommand<ManometreDePression>(id), new CancellationToken());
        #endregion
    }
}
