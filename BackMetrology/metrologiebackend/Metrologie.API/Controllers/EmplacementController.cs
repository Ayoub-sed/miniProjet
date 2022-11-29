//using AutoMapper;
//using Metrologie.Domain.Commands;
//using Metrologie.Domain.Handlers;
//using Metrologie.Domain.Interfaces;
//using Metrologie.Domain.Models;
//using Metrologie.Domain.Queries;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Metrologie.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EmplacementController : ControllerBase
//    {


//        private readonly IGenericRepository<Emplacement> repository;
//        private readonly IMapper mapper;

//        #region Constructor
//        public EmplacementController(IGenericRepository<Emplacement> repository, IMapper mapper)
//        {
//            this.repository = repository;
//            this.mapper = mapper;

//        }
//        #endregion

//        #region Read Function
//        // GET: api/Emplacement
//        [HttpGet("GetListEmplacement")]
//        public async Task<IEnumerable<Emplacement>> GetListEmplacement() =>
//             await (new GetListGenericHandler<Emplacement>(repository)).Handle(new GetListGenericQuery<Emplacement>(condition: null, includes: null), new CancellationToken());

//        // GET: api/Critere/5
//        [HttpGet("GetEmplacement")]
//        public async Task<Emplacement> GetEmplacement(Guid id) =>
//            await (new GetGenericHandler<Emplacement>(repository)).Handle(new GetGenericQuery<Emplacement>(condition: x => x.EmplacementId.Equals(id), null), new CancellationToken());
//        #endregion

//        #region Add Function
//        // POST: api/Emplacement
//        [HttpPost("PostEmplacement")]
//        public async Task<Emplacement> PostEmplacement([FromBody] Emplacement Emplacement) =>
//            await (new AddGenericHandler<Emplacement>(repository)).Handle(new AddGenericCommand<Emplacement>(Emplacement), new CancellationToken());
//        #endregion

//        #region Update Funtion
//        // PUT: api/Emplacement
//        [HttpPut("PutEmplacement")]
//        public async Task<Emplacement> PutEmplacement([FromBody] Emplacement Emplacement) =>
//           await (new PutGenericHandler<Emplacement>(repository)).Handle(new PutGenericCommand<Emplacement>(Emplacement), new CancellationToken());
//        #endregion

//        #region Remove Function
//        // DELETE: api/Emplacement/5
//        [HttpDelete("DeleteEmplacement")]
//        public async Task<Emplacement> DeleteEmplacement(Guid id) =>
//           await (new RemoveGenericHandler<Emplacement>(repository)).Handle(new RemoveGenericCommand<Emplacement>(id), new CancellationToken());
//        #endregion
//    }
//}  ( Hatem )
