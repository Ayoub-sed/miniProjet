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
    public class EquipementController : ControllerBase
    {
        private readonly IGenericRepository<Equipement> repository;
        private readonly IGenericRepository<Bain> repositorybain;
        private readonly IMapper mapper;

        #region Constructor
        public EquipementController(IGenericRepository<Equipement> repository, IMapper mapper, IGenericRepository<Bain> repositorybain)
        {
            this.repository = repository;
            this.repositorybain = repositorybain;
            this.mapper = mapper;

        }
        #endregion

        #region Read Function
        // GET: api/Equipement
        [HttpGet("GetListEquipementDto")]
        public async Task<IEnumerable<Equipement>> GetListEquipementDto() =>
             await (new GetListGenericHandler<Equipement>(repository)).Handle(new GetListGenericQuery<Equipement>(condition: null, includes: null), new CancellationToken());

        // GET: api/Equipement
        [HttpGet("GetListEquipementDtoByFiliale")]
        public async Task<IEnumerable<EquipementDto>> GetListEquipementDtoByFiliale(Guid id) =>
              (new GetListGenericHandler<Equipement>(repository)).Handle(new GetListGenericQuery<Equipement>(condition: x => x.FkFiliale.Equals(id), includes: null), new CancellationToken())
                                .Result.Select(data => mapper.Map<EquipementDto>(data));


        // GET: api/Bain
        [HttpGet("GetListEquipement")]
        public async Task<IEnumerable<EquipementDto>> GetListEquipement() =>
         (new GetListGenericHandler<Equipement>(repository)).Handle(new GetListGenericQuery<Equipement>(condition: null, includes: null), new CancellationToken())
                        .Result.Select(data => mapper.Map<EquipementDto>(data));

        // GET: api/Equipement/5
        [HttpGet("GetEquipement")]
        public async Task<Equipement> GetEquipement(Guid id) =>
            await (new GetGenericHandler<Equipement>(repository)).Handle(new GetGenericQuery<Equipement>(condition: x => x.EquipementId.Equals(id), null), new CancellationToken());
        // GET: api/Equipement/5

        [HttpGet("GetEquipementByType")]
        public async Task<IEnumerable<Equipement>> GetEquipementByType(String nr) =>
            await (new GetListGenericHandler<Equipement>(repository)).Handle(new GetListGenericQuery<Equipement>(condition: x => x.Type.Equals(nr), null), new CancellationToken());


            


        [HttpGet("GetListEquipementGroupedByLibelle")]
        public async Task<List<GroupedEquipementsDTO>> GetListEquipementGroupedByLibelle()
        {
     
            var listEmptySector = new List<GroupedEquipementsDTO>();


            var listA = GetListEquipement().Result.ToList().Select(n => n.Libelle).Distinct();
            var listEQ = GetListEquipement().Result.ToList();
            foreach (var item in listA)
            {
                var listeCommune = listEQ.Where(x => x.Libelle == item);
                var element = new GroupedEquipementsDTO();
                element.Libelle = item;
                element.EquipementDto = listeCommune.ToList();
                listEmptySector.Add(element);
            }
            return listEmptySector;


        }
        #endregion

        #region Add Function
        // POST: api/Equipement
        [HttpPost("PostEquipement")]
        public async Task<Equipement> PostEquipement([FromBody] Equipement Equipement) =>
            await (new AddGenericHandler<Equipement>(repository)).Handle(new AddGenericCommand<Equipement>(Equipement), new CancellationToken());
        #endregion

        
        #region Update Funtion
        // PUT: api/Equipement
        [HttpPut("PutEquipement")]
        public async Task<Equipement> PutEquipement([FromBody] Equipement Equipement) =>
           await (new PutGenericHandler<Equipement>(repository)).Handle(new PutGenericCommand<Equipement>(Equipement), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/Equipement/5
        [HttpDelete("DeleteEquipement")]
        public async Task<Equipement> DeleteEquipement(Guid id) =>
           await (new RemoveGenericHandler<Equipement>(repository)).Handle(new RemoveGenericCommand<Equipement>(id), new CancellationToken());
        #endregion
    }
}
