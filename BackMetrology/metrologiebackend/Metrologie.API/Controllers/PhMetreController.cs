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
    public class PhMetreController : ControllerBase
    {

        private readonly IGenericRepository<PhMetre> repository;
        private readonly IMapper mapper;

        #region Constructor
        public PhMetreController(IGenericRepository<PhMetre> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }
        #endregion

        #region Read Function
        // GET: api/PhMetre
        [HttpGet("GetListPhMetre")]
        public async Task<IEnumerable<PhMetre>> GetListPhMetre() =>
             await (new GetListGenericHandler<PhMetre>(repository)).Handle(new GetListGenericQuery<PhMetre>(condition: null, includes: null), new CancellationToken());

        // GET: api/PhMetre/5
        [HttpGet("GetPhMetre")]
        public async Task<PhMetre> GetPhMetre(Guid id) =>
            await (new GetGenericHandler<PhMetre>(repository)).Handle(new GetGenericQuery<PhMetre>(condition: x => x.EquipementId.Equals(id), null), new CancellationToken());
        #endregion

        #region Add Function
        // POST: api/PhMetre
        [HttpPost("PostPhMetre")]
        public async Task<PhMetre> PostPhMetre([FromBody] PhMetre PhMetre) =>
            await (new AddGenericHandler<PhMetre>(repository)).Handle(new AddGenericCommand<PhMetre>(PhMetre), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/PhMetre
        [HttpPut("PutPhMetre")]
        public async Task<PhMetre> PutPhMetre([FromBody] PhMetre PhMetre) =>
           await (new PutGenericHandler<PhMetre>(repository)).Handle(new PutGenericCommand<PhMetre>(PhMetre), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/PhMetre/5
        [HttpDelete("DeletePhMetre")]
        public async Task<PhMetre> DeletePhMetre(Guid id) =>
           await (new RemoveGenericHandler<PhMetre>(repository)).Handle(new RemoveGenericCommand<PhMetre>(id), new CancellationToken());
        #endregion
    }
}


