using AutoMapper;
using Metrologie.Domain.Commands;
using Metrologie.Domain.Handlers;
using Metrologie.Domain.Interfaces;
using Metrologie.Domain.Models;
//using Metrologie.Domain.Queries;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Metrologie.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EquipementInterventionController : ControllerBase
//    {
//        private readonly IGenericRepository<EquipementIntervention> repository;
//        private readonly IMapper mapper;

//        #region Constructor
//        public EquipementInterventionController(IGenericRepository<EquipementIntervention> repository, IMapper mapper)
//        {
//            this.repository = repository;
//            this.mapper = mapper;

//        }
//        #endregion

//        #region Read Function
//        // GET: api/EquipementTypeIntervention
//        [HttpGet("GetListEquipementTypeIntervention")]
//        public async Task<IEnumerable<EquipementIntervention>> GetListEquipementTypeIntervention() =>
//             await (new GetListGenericHandler<EquipementIntervention>(repository)).Handle(new GetListGenericQuery<EquipementIntervention>(condition: null, includes: null), new CancellationToken());

//        // GET: api/EquipementTypeIntervention/5
//        [HttpGet("GetEquipementTypeIntervention")]
//        public async Task<EquipementIntervention> GetEquipementTypeIntervention(Guid id) =>
//            await (new GetGenericHandler<EquipementIntervention>(repository)).Handle(new GetGenericQuery<EquipementIntervention>(condition: x => x.EquipementInterventionId.Equals(id), null), new CancellationToken());
//        #endregion

//        #region Add Function
//        // POST: api/EquipementTypeIntervention
//        [HttpPost("PostEquipementTypeIntervention")]
//        public async Task<EquipementIntervention> PostEquipementTypeIntervention([FromBody] EquipementIntervention EquipementTypeIntervention) =>
//            await (new AddGenericHandler<EquipementIntervention>(repository)).Handle(new AddGenericCommand<EquipementIntervention>(EquipementTypeIntervention), new CancellationToken());
//        #endregion

//        #region Update Funtion
//        // PUT: api/EquipementTypeIntervention
//        [HttpPut("PutEquipementTypeIntervention")]
//        public async Task<EquipementIntervention> PutEquipementTypeIntervention([FromBody] EquipementIntervention EquipementTypeIntervention) =>
//           await (new PutGenericHandler<EquipementIntervention>(repository)).Handle(new PutGenericCommand<EquipementIntervention>(EquipementTypeIntervention), new CancellationToken());
//        #endregion

//        #region Remove Function
//        // DELETE: api/EquipementTypeIntervention/5
//        [HttpDelete("DeleteEquipementTypeIntervention")]
//        public async Task<EquipementIntervention> DeleteEquipementTypeIntervention(Guid id) =>
//           await (new RemoveGenericHandler<EquipementIntervention>(repository)).Handle(new RemoveGenericCommand<EquipementIntervention>(id), new CancellationToken());
//        #endregion
//    }
//}
