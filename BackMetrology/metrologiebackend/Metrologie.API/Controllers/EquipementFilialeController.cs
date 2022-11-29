//using AutoMapper;
//using Metrologie.Domain.Commands;
//using Metrologie.Domain.Handlers;
//using Metrologie.Domain.Interfaces;
//using Metrologie.Domain.Models;
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
//    public class EquipementFilialeController : ControllerBase
//    {
//        private readonly IGenericRepository<EquipementFiliale> repository;
//        private readonly IMapper mapper;

//        #region Constructor
//        public EquipementFilialeController(IGenericRepository<EquipementFiliale> repository, IMapper mapper)
//        {
//            this.repository = repository;
//            this.mapper = mapper;

//        }
//        #endregion

//        #region Read Function
//        // GET: api/EquipementFiliale
//        [HttpGet("GetListEquipementFiliale")]
//        public async Task<IEnumerable<EquipementFiliale>> GetListEquipementFiliale() =>
//             await (new GetListGenericHandler<EquipementFiliale>(repository)).Handle(new GetListGenericQuery<EquipementFiliale>(condition: null, includes: null), new CancellationToken());

//        // GET: api/EquipementFiliale/5
//        [HttpGet("GetEquipementFiliale")]
//        public async Task<EquipementFiliale> GetEquipementFiliale(Guid id) =>
//            await (new GetGenericHandler<EquipementFiliale>(repository)).Handle(new GetGenericQuery<EquipementFiliale>(condition: x => x.EquipementFilialeId.Equals(id), null), new CancellationToken());
//        #endregion

//        #region Add Function
//        // POST: api/EquipementFiliale
//        [HttpPost("PostEquipementFiliale")]
//        public async Task<EquipementFiliale> PostEquipementFiliale([FromBody] EquipementFiliale EquipementFiliale) =>
//            await (new AddGenericHandler<EquipementFiliale>(repository)).Handle(new AddGenericCommand<EquipementFiliale>(EquipementFiliale), new CancellationToken());
//        #endregion

//        #region Update Funtion
//        // PUT: api/EquipementFiliale
//        [HttpPut("PutEquipementFiliale")]
//        public async Task<EquipementFiliale> PutEquipementFiliale([FromBody] EquipementFiliale EquipementFiliale) =>
//           await (new PutGenericHandler<EquipementFiliale>(repository)).Handle(new PutGenericCommand<EquipementFiliale>(EquipementFiliale), new CancellationToken());
//        #endregion

//        #region Remove Function
//        // DELETE: api/EquipementFiliale/5
//        [HttpDelete("DeleteEquipementFiliale")]
//        public async Task<EquipementFiliale> DeleteEquipementFiliale(Guid id) =>
//           await (new RemoveGenericHandler<EquipementFiliale>(repository)).Handle(new RemoveGenericCommand<EquipementFiliale>(id), new CancellationToken());
//        #endregion
//    }
//} ( Hatem ) 
