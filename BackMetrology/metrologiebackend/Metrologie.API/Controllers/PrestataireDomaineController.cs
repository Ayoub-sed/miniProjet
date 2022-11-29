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
//    public class PrestataireDomaineController : ControllerBase
//    {
//        private readonly IGenericRepository<PrestataireDomaine> repository;
//        private readonly IMapper mapper;

//        #region Constructor
//        public PrestataireDomaineController(IGenericRepository<PrestataireDomaine> repository, IMapper mapper)
//        {
//            this.repository = repository;
//            this.mapper = mapper;

//        }
//        #endregion

//        #region Read Function
//        // GET: api/PrestataireDomaine
//        [HttpGet("GetListPrestataireDomaine")]
//        public async Task<IEnumerable<PrestataireDomaine>> GetListPrestataireDomaine() =>
//             await (new GetListGenericHandler<PrestataireDomaine>(repository)).Handle(new GetListGenericQuery<PrestataireDomaine>(condition: null, includes: null), new CancellationToken());

//        // GET: api/PrestataireDomaine/5
//        [HttpGet("GetPrestataireDomaine")]
//        public async Task<PrestataireDomaine> GetPrestataireDomaine(Guid id) =>
//            await (new GetGenericHandler<PrestataireDomaine>(repository)).Handle(new GetGenericQuery<PrestataireDomaine>(condition: x => x.PrestataireDomaineId.Equals(id), null), new CancellationToken());
//        #endregion

//        #region Add Function
//        // POST: api/PrestataireDomaine
//        [HttpPost("PostPrestataireDomaine")]
//        public async Task<PrestataireDomaine> PostRangePrestataireDomaine([FromBody] PrestataireDomaine PrestataireDomaine) =>
//            await (new AddGenericHandler<PrestataireDomaine>(repository)).Handle(new AddGenericCommand<PrestataireDomaine>(PrestataireDomaine), new CancellationToken());


//        // POST: api/PrestataireDomaine
//        [HttpPost("PostRangePrestataireDomaine")]
//        public async Task<string> PostPrestataireDomaine([FromBody]  List<PrestataireDomaine> PrestatairesDomaines)
//        {
//            var command = (new AddRangeGenericCommand<PrestataireDomaine>(PrestatairesDomaines));
//            var handler = new PostRangeGenenricHandler<PrestataireDomaine>(repository);
//            var result = (await handler.Handle(command, new CancellationToken()));
//            return result; 
//        }
//        #endregion

//        #region Update Funtion
//        // PUT: api/PrestataireDomaine
//        [HttpPut("PutPrestataireDomaine")]
//        public async Task<PrestataireDomaine> PutPrestataireDomaine([FromBody] PrestataireDomaine PrestataireDomaine) =>
//           await (new PutGenericHandler<PrestataireDomaine>(repository)).Handle(new PutGenericCommand<PrestataireDomaine>(PrestataireDomaine), new CancellationToken());
//        #endregion

//        #region Remove Function
//        // DELETE: api/PrestataireDomaine/5
//        [HttpDelete("DeletePrestataireDomaine")]
//        public async Task<PrestataireDomaine> DeletePrestataireDomaine(Guid id) =>
//           await (new RemoveGenericHandler<PrestataireDomaine>(repository)).Handle(new RemoveGenericCommand<PrestataireDomaine>(id), new CancellationToken());
//        #endregion
//    }
//} ( Hatem ) 
