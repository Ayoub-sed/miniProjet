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
    public class CritereController : ControllerBase
    {
        private readonly IGenericRepository<Critere> repository;
        private readonly IMapper mapper;
        private readonly IGenericRepository<NoteCritere> repositoryNote;
      
        #region Constructor
        public CritereController(IGenericRepository<Critere> repository, IMapper mapper, IGenericRepository<NoteCritere> repositoryNote)
        {
            this.repositoryNote = repositoryNote;
            this.repository = repository;
            this.mapper = mapper;

        }
        #endregion

        #region Read Function
        // GET: api/NoteCritere
        [HttpGet("GetNoteCritereByfilialByDate")]
        public async Task<IEnumerable<NoteCritereDTO>> GetNoteCritereByfilialByDate(Guid id2, DateTime dateSearch) =>
        (new GetListGenericHandler<NoteCritere>(repositoryNote)).Handle(new GetListGenericQuery<NoteCritere>(condition: x => x.FkFiliale.Equals(id2) && x.DateDebut.Month == dateSearch.Month && x.DateDebut.Year == dateSearch.Year, includes: x => x.Include(a => a.Critere)), new CancellationToken())
        .Result.Select(data => mapper.Map<NoteCritereDTO>(data));


        // GET: api/NoteCritere/5
        [HttpGet("GetCriteretNoteCritereByfilialByDate")]
        public async Task<NoteCritere> GetCriteretNoteCritereByfilialByDate(Guid id1, Guid id2, DateTime dateSearch) =>
            await (new GetGenericHandler<NoteCritere>(repositoryNote)).Handle(new GetGenericQuery<NoteCritere>(condition: x => x.FkCritere.Equals(id1) && x.FkFiliale.Equals(id2) && x.DateDebut.Month == dateSearch.Month && x.DateDebut.Year == dateSearch.Year, includes: x => x.Include(a => a.Critere)), new CancellationToken());



        // GET: api/Critere
        [HttpGet("GetListCritere")]
        public async Task<IEnumerable<Critere>> GetListCritere() =>
             await (new GetListGenericHandler<Critere>(repository))
            .Handle(new GetListGenericQuery<Critere>(condition: null, includes: null), 
                 new CancellationToken());

        // GET: api/Critere
        [HttpGet("GetListCritereNoteDto")]
        public async Task<IEnumerable<CritereNoteDto>> GetListCritereNoteDto() =>
              (new GetListGenericHandler<Critere>(repository)).Handle(new GetListGenericQuery<Critere>(condition: null, includes: null), new CancellationToken())
                .Result.Select(data => mapper.Map<CritereNoteDto>(data));

      
        // GET: api/Critere/5
        [HttpGet("GetCritere")]
        public async Task<Critere> GetCritere(Guid id) =>
            await (new GetGenericHandler<Critere>(repository)).Handle(new GetGenericQuery<Critere>(condition: x => x.CritereId.Equals(id), null), new CancellationToken());

        [HttpGet("GetListCritereGroupedByAxe")]
        public async Task<List<GroupedCritereDTO>> GetListCritereGroupedByAxe()
        {
            //IEnumerable<GroupedCritereDTO> list = new List<GroupedCritereDTO>();
            var listEmptySector = new List<GroupedCritereDTO>();


            var listA = GetListCritere().Result.ToList().Select(n => n.Axe).Distinct();
            var listCriteres = GetListCritere().Result.ToList();
            foreach (var item in listA)
            {
                var listeCommune = listCriteres.Where(x => x.Axe == item);
                var element = new GroupedCritereDTO();
                element.Axe = item;
                element.Critere = listeCommune.ToList();
                listEmptySector.Add(element);
            }
            return listEmptySector;


        }



        [HttpGet("GetListCritereGroupedByAxeByType")]
        public async Task<List<GroupedCritereDTO>> GetListCritereGroupedByAxeByType()
        {
            //IEnumerable<GroupedCritereDTO> list = new List<GroupedCritereDTO>();
            var listEmptySector = new List<GroupedCritereDTO>();


            var listA = GetListCritere().Result.ToList().Select(n => n.Axe).Distinct();
            var listCriteres = GetListCritere().Result.ToList();

            foreach (var item in listA)
            {
               
                var listeCommune = listCriteres.Where(x => x.Axe == item);

                var element = new GroupedCritereDTO();
                element.Axe = item;
                element.Critere = listeCommune.ToList();
                listEmptySector.Add(element);
            }
            return listEmptySector;


        }



        [HttpGet("GetListCritereGroupedByAxeWithNote")]
        public async Task<List<GroupeCritereNoteDto>> GetListCritereGroupedByAxeWithNote(Guid idF, DateTime dateSearch)
        {
            //IEnumerable<GroupedCritereDTO> list = new List<GroupedCritereDTO>();
            var listEmptySector = new List<GroupeCritereNoteDto>();
            var listEmptySector1 = new List<GroupeCritereNoteDto>();
            var element1 = new GroupeCritereNoteDto();

            var listA = GetListCritereNoteDto().Result.ToList().Select(n => n.Axe).Distinct();
            var listCriteres = GetListCritereNoteDto().Result.ToList();
            double na =0 ;
            var sc = 0;
            foreach (var item in listA)
            {
                na = 0;
                var listeCommune = listCriteres.Where(x => x.Axe == item);
                var element = new GroupeCritereNoteDto();
                element.Axe = item;
                element.Critere = listeCommune.ToList();
                foreach(var s in element.Critere)
                {
                    sc += s.Coefficient; 
                }
                foreach(var i in element.Critere)
                {
                    var crn = GetCriteretNoteCritereByfilialByDate(i.CritereId, idF, dateSearch).Result;
                    if(crn != null)
                    {
                        i.note = crn.Note;
                        i.done = crn.Done;
                        na += (i.note * i.Coefficient) ;
                        
                    }
                    else
                    {
                        sc -= i.Coefficient;
                    }
                }
                element.NoteAxe = Math.Round(na/sc,2);
                
                listEmptySector.Add(element);
            }
          
            return listEmptySector;


        }

        #endregion

        #region Add Function
        // POST: api/Critere
        [HttpPost("PostCritere")]
        public async Task<Critere> PostCritere([FromBody] Critere Critere) =>
            await (new AddGenericHandler<Critere>(repository)).Handle(new AddGenericCommand<Critere>(Critere), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/Critere
        [HttpPut("PutCritere")]
        public async Task<Critere> PutCritere([FromBody] Critere Critere) =>
           await (new PutGenericHandler<Critere>(repository)).Handle(new PutGenericCommand<Critere>(Critere), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/Critere/5
        [HttpDelete("DeleteCritere")]
        public async Task<Critere> DeleteCritere(Guid id) =>
           await (new RemoveGenericHandler<Critere>(repository)).Handle(new RemoveGenericCommand<Critere>(id), new CancellationToken());
        #endregion
    }
}
