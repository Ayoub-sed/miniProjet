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
    public class PrestataireController : ControllerBase
    {
        private readonly IGenericRepository<Prestataire> repository;
        //private readonly IGenericRepository<PrestataireDomaine> preDoRepository;
        private readonly IMapper mapper;

        #region Constructor
        public PrestataireController(IGenericRepository<Prestataire> repository, IMapper mapper)
        {
            this.repository = repository;
            //this.preDoRepository = preDoRepository;
            this.mapper = mapper;

        }
        #endregion

        #region Read Function
        // GET: api/Prestataire
        [HttpGet("GetListPrestataire")]
        public async Task<IEnumerable<Prestataire>> GetListPrestataire() =>
             await (new GetListGenericHandler<Prestataire>(repository)).Handle(new GetListGenericQuery<Prestataire>(condition: null, includes: null), new CancellationToken());

        [HttpGet("GetListPrestataireDto")]
        public async Task<IEnumerable<PrestataireDto>> GetListPrestataireDto()
        {
            List<PrestataireDto> ListPrestataireDtoForGet = new List<PrestataireDto>();
            PrestataireDto PrestForGet = new PrestataireDto();
            var ListPrestataireDto =  (new GetListGenericHandler<Prestataire>(repository))
                .Handle(new GetListGenericQuery<Prestataire>(condition: null, includes: null), new CancellationToken())
                .Result.Select(data => mapper.Map<PrestataireDto>(data));
            bool isExist = false;
            foreach (var Prest in ListPrestataireDto)
            {
                
                //var res = (new GetListGenericHandler<PrestataireDomaine>(preDoRepository))
                //    .Handle(new GetListGenericQuery<PrestataireDomaine>(condition: a => a.FkPrestataire.Equals(Prest.PrestataireId), includes: x => x.Include(y => y.Domaine)), new CancellationToken())
                //    .Result.Select(data => mapper.Map<PrestataireDomaineDto>(data));
                //if (res != null)
                //{
                //    PrestForGet = Prest;
                //    PrestForGet.ListPresDomDto = new List<PrestataireDomaineDto>();
                //    foreach (var PrestDom in res)
                //    {
                //        PrestForGet.ListPresDomDto.Add(PrestDom);
                //        foreach (var P in ListPrestataireDtoForGet)
                //        {
                //            isExist = P.PrestataireId.Equals(PrestForGet.PrestataireId);
                //        }
                //        if (!isExist)
                //        {
                //            ListPrestataireDtoForGet.Add(PrestForGet);
                //        }
                //    }
                //}
                //else
                //{
                    ListPrestataireDtoForGet.Add(Prest);
                }
                
            //}
            return ListPrestataireDtoForGet;
        }

        // GET: api/Prestataire/5
        [HttpGet("GetPrestataire")]
        public async Task<Prestataire> GetPrestataire(Guid id) =>
            await (new GetGenericHandler<Prestataire>(repository)).Handle(new GetGenericQuery<Prestataire>(condition: x => x.PrestataireId.Equals(id), null), new CancellationToken());
        #endregion

        #region Add Function
        // POST: api/Prestataire
        [HttpPost("PostPrestataire")]
        public async Task<Prestataire> PostPrestataire([FromBody] Prestataire Prestataire) =>
            await (new AddGenericHandler<Prestataire>(repository)).Handle(new AddGenericCommand<Prestataire>(Prestataire), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/Prestataire
        [HttpPut("PutPrestataire")]
        public async Task<Prestataire> PutPrestataire([FromBody] Prestataire Prestataire) =>
           await (new PutGenericHandler<Prestataire>(repository)).Handle(new PutGenericCommand<Prestataire>(Prestataire), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/Prestataire/5
        [HttpDelete("DeletePrestataire")]
        public async Task<Prestataire> DeletePrestataire(Guid id) {
            Prestataire prestDeleted = new Prestataire();
            //List<PrestataireDomaine> predomList = (new GetListGenericHandler<PrestataireDomaine>(preDoRepository)).Handle(new GetListGenericQuery<PrestataireDomaine>(condition: x => x.FkPrestataire.Equals(id), null), new CancellationToken()).Result.ToList();
            //if (predomList.Count() != 0) { 
            //    foreach(var predom in predomList) { 
            //    await (new RemoveGenericHandler<PrestataireDomaine>(preDoRepository)).Handle(new RemoveGenericCommand<PrestataireDomaine>(predom.PrestataireDomaineId), new CancellationToken());
            //    }
            //    prestDeleted = await(new RemoveGenericHandler<Prestataire>(repository)).Handle(new RemoveGenericCommand<Prestataire>(id), new CancellationToken());
            //}
            //else {
                prestDeleted = await(new RemoveGenericHandler<Prestataire>(repository)).Handle(new RemoveGenericCommand<Prestataire>(id), new CancellationToken());
            //}
            return prestDeleted;
        }
        #endregion

    }
}
