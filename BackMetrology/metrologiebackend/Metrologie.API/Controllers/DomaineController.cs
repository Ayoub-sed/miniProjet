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
//    public class DomaineController : ControllerBase
//    {
//        private readonly IGenericRepository<Domaine> repository;
//        private readonly IMapper mapper;

//        #region Constructor
//        public DomaineController(IGenericRepository<Domaine> repository, IMapper mapper)
//        {
//            this.repository = repository;
//            this.mapper = mapper;

//        }
//        #endregion

//        #region Read Function
//        // GET: api/Domaine
//        [HttpGet("GetListDomaine")]
//        public async Task<IEnumerable<Domaine>> GetListDomaine() =>
//             await (new GetListGenericHandler<Domaine>(repository)).Handle(new GetListGenericQuery<Domaine>(condition: null, includes: null), new CancellationToken());

//        // GET: api/Domaine/5
//        [HttpGet("GetDomaine")]
//        public async Task<Domaine> GetDomaine(Guid id) =>
//            await (new GetGenericHandler<Domaine>(repository)).Handle(new GetGenericQuery<Domaine>(condition: x => x.DomaineId.Equals(id), null), new CancellationToken());
//        #endregion

//        #region Add Function
//        // POST: api/Domaine
//        [HttpPost("PostDomaine")]
//        public async Task<Domaine> PostDomaine([FromBody] Domaine Domaine) =>
//            await (new AddGenericHandler<Domaine>(repository)).Handle(new AddGenericCommand<Domaine>(Domaine), new CancellationToken());
//        #endregion

//        #region Update Funtion
//        // PUT: api/Domaine
//        [HttpPut("PutDomaine")]
//        public async Task<Domaine> PutDomaine([FromBody] Domaine Domaine) =>
//           await (new PutGenericHandler<Domaine>(repository)).Handle(new PutGenericCommand<Domaine>(Domaine), new CancellationToken());
//        #endregion

//        #region Remove Function
//        // DELETE: api/Domaine/5
//        [HttpDelete("DeleteDomaine")]
//        public async Task<Domaine> DeleteDomaine(Guid id) =>
//           await (new RemoveGenericHandler<Domaine>(repository)).Handle(new RemoveGenericCommand<Domaine>(id), new CancellationToken());
//        #endregion

//    }
//} ( Hatem ) 
