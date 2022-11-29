using AutoMapper;
using Metrologie.Domain.Commands;
using Metrologie.Domain.Dtos;
using Metrologie.Domain.Handlers;
using Metrologie.Domain.Interfaces;
using Metrologie.Domain.Models;
using Metrologie.Domain.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Metrologie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteCritereController : ControllerBase
    {
        private readonly IGenericRepository<NoteCritere> repository;
        private readonly IMapper mapper;
        #region Constructor
        public NoteCritereController(IGenericRepository<NoteCritere> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        #endregion
        #region Read Function
        // GET: api/NoteCritere
        [HttpGet("GetListNoteCritere")]
        public async Task<IEnumerable<NoteCritereDTO>> GetListNoteCritere() =>
        (new GetListGenericHandler<NoteCritere>(repository)).Handle(new GetListGenericQuery<NoteCritere>(condition: null, includes: x => x.Include(a => a.Critere)), new CancellationToken())
        .Result.Select(data => mapper.Map<NoteCritereDTO>(data));

        // GET: api/NoteCritere/5
        [HttpGet("GetNoteCritere")]
        public async Task<NoteCritere> GetNoteCritere(Guid id) =>
            await (new GetGenericHandler<NoteCritere>(repository)).Handle(new GetGenericQuery<NoteCritere>(condition: x => x.NoteCritereId.Equals(id), includes: x => x.Include(a => a.Critere)), new CancellationToken());

        // GET: api/NoteCritere
        [HttpGet("GetNoteCritereByfilial")]
        public async Task<IEnumerable<NoteCritereDTO>> GetNoteCritereByfilial(Guid id1 , Guid id2) =>
        (new GetListGenericHandler<NoteCritere>(repository)).Handle(new GetListGenericQuery<NoteCritere>(condition: x => x.FkCritere.Equals(id1)  && x.FkFiliale.Equals(id2) && x.DateDebut.Month == DateTime.Now.Month && x.DateDebut.Year == DateTime.Now.Year, includes: x => x.Include(a => a.Critere)), new CancellationToken())
        .Result.Select(data => mapper.Map<NoteCritereDTO>(data));
      
   

        // GET: api/NoteCritere/5
        [HttpGet("GetCriteretNoteCritereByfilialByDate")]
        public async Task<NoteCritere> GetCriteretNoteCritereByfilialByDate(Guid id1, Guid id2, DateTime dateSearch) =>
            await (new GetGenericHandler<NoteCritere>(repository)).Handle(new GetGenericQuery<NoteCritere>(condition: x => x.FkCritere.Equals(id1) && x.FkFiliale.Equals(id2) && x.DateDebut.Month == dateSearch.Month && x.DateDebut.Year == dateSearch.Year, includes: x => x.Include(a => a.Critere)), new CancellationToken());

        // GET: api/NoteCritere
        [HttpGet("GetNoteCritereByfilialByDate")]
        public async Task<IEnumerable<NoteCritereDTO>> GetNoteCritereByfilialByDate(Guid id2, DateTime dateSearch) =>
        (new GetListGenericHandler<NoteCritere>(repository)).Handle(new GetListGenericQuery<NoteCritere>(condition: x => x.FkFiliale.Equals(id2) && x.DateDebut.Month == dateSearch.Month && x.DateDebut.Year == dateSearch.Year, includes: x => x.Include(a => a.Critere)), new CancellationToken())
        .Result.Select(data => mapper.Map<NoteCritereDTO>(data));

        #endregion
        #region Add Function
        // POST: api/NoteCritere
        [HttpPost("PostNoteCritere")]
        public async Task<NoteCritere> PostNoteCritere([FromBody] NoteCritere NoteCritere) =>
            await (new AddGenericHandler<NoteCritere>(repository)).Handle(new AddGenericCommand<NoteCritere>(NoteCritere), new CancellationToken());
        #endregion
        #region Update Funtion
        // PUT: api/NoteCritere
        [HttpPut("PutNoteCritere")]
        public async Task<NoteCritere> PutNoteCritere([FromBody] NoteCritere NoteCritere) =>
           await (new PutGenericHandler<NoteCritere>(repository)).Handle(new PutGenericCommand<NoteCritere>(NoteCritere), new CancellationToken());
        #endregion
        #region Remove Function
        // DELETE: api/NoteCritere/5
        [HttpDelete("DeleteNoteCritere")]
        public async Task<NoteCritere> DeleteNoteCritere(Guid id) =>
           await (new RemoveGenericHandler<NoteCritere>(repository)).Handle(new RemoveGenericCommand<NoteCritere>(id), new CancellationToken());
        #endregion
    }
}
