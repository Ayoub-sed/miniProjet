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
    public class FourController : ControllerBase
    {
        private readonly IGenericRepository<Four> repository;
        private readonly IMapper mapper;

        #region Constructor
        public FourController(IGenericRepository<Four> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }
        #endregion

        #region Read Function
        // GET: api/Four
        [HttpGet("GetListFour")]
        public async Task<IEnumerable<Four>> GetListFour() =>
             await (new GetListGenericHandler<Four>(repository)).Handle(new GetListGenericQuery<Four>(condition: null, includes: null), new CancellationToken());

        // GET: api/Four/5
        [HttpGet("GetFour")]
        public async Task<Four> GetFour(Guid id) =>
            await (new GetGenericHandler<Four>(repository)).Handle(new GetGenericQuery<Four>(condition: x => x.EquipementId.Equals(id), null), new CancellationToken());
        #endregion

        #region Add Function
        // POST: api/Four
        [HttpPost("PostFour")]
        public async Task<Four> PostFour([FromBody] Four Four) =>
            await (new AddGenericHandler<Four>(repository)).Handle(new AddGenericCommand<Four>(Four), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/Four
        [HttpPut("PutFour")]
        public async Task<Four> PutFour([FromBody] Four Four) =>
           await (new PutGenericHandler<Four>(repository)).Handle(new PutGenericCommand<Four>(Four), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/Four/5
        [HttpDelete("DeleteFour")]
        public async Task<Four> DeleteFour(Guid id) =>
           await (new RemoveGenericHandler<Four>(repository)).Handle(new RemoveGenericCommand<Four>(id), new CancellationToken());
        #endregion
    }
}
