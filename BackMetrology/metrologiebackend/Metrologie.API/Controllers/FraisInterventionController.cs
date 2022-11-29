//using AutoMapper;
//using Metrologie.Domain.Commands;
//using Metrologie.Domain.Dtos;
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
//    public class FraisInterventionController : ControllerBase
//    {
//        private readonly IGenericRepository<FraisIntervention> repository;
//        private readonly IMapper mapper;
//        #region Constructor
//        public FraisInterventionController(IGenericRepository<FraisIntervention> repository, IMapper mapper)
//        {
//            this.repository = repository;
//            this.mapper = mapper;
//        }
//        #endregion
//        #region Read Function
//        // GET: api/FraisIntervention
//        [HttpGet("GetListFraisIntervention")]
//        public async Task<IEnumerable<FraisIntervention>> GetListFraisIntervention() =>
//             await (new GetListGenericHandler<FraisIntervention>(repository)).Handle(new GetListGenericQuery<FraisIntervention>(condition: null, includes: null), new CancellationToken());

//        // GET: api/FraisIntervention/5
//        [HttpGet("GetFraisIntervention")]
//        public async Task<FraisIntervention> GetFraisIntervention(Guid id) =>
//            await (new GetGenericHandler<FraisIntervention>(repository)).Handle(new GetGenericQuery<FraisIntervention>(condition: x => x.FraisInterventionId.Equals(id), null), new CancellationToken());

//        [HttpGet("GetListFraisInterventionByTypeIntervention")]
//        public async Task<List<GroupFraisInterventionDto>> GetListFraisInterventionByTypeIntervention(Guid fkFiliale, DateTime dateintervention)
//        {
//            var listEmptySector = new List<GroupFraisInterventionDto>();


//            var listA = GetListFraisIntervention().Result.ToList().Select(n => n.TypeIntervention).Distinct();
//            var listFraisIntervention = GetListFraisIntervention().Result.ToList();
//            foreach (var item in listA)
//            {
//                var listeCommune = listFraisIntervention.Where(x => x.TypeIntervention == item && x.FkFiliale == fkFiliale && x.DateIntervention.Year == dateintervention.Year);
//                var listeAllType = listFraisIntervention.Where(x => x.FkFiliale == fkFiliale && x.DateIntervention.Year == dateintervention.Year);
//                var somme = listeCommune.Sum(x => x.Frais);
//                var element = new GroupFraisInterventionDto();
//                element.TypeIntervention = item;
//                element.sommeFrais = somme;
//                element.FraisIntervention = listeCommune.ToList();
//                listEmptySector.Add(element);
//            }
//            return listEmptySector;


//        }
//        #endregion
//        #region Add Function
//        // POST: api/FraisIntervention
//        [HttpPost("PostFraisIntervention")]
//        public async Task<FraisIntervention> PostFraisIntervention([FromBody] FraisIntervention FraisIntervention) =>
//            await (new AddGenericHandler<FraisIntervention>(repository)).Handle(new AddGenericCommand<FraisIntervention>(FraisIntervention), new CancellationToken());
//        #endregion
//        #region Update Funtion
//        // PUT: api/FraisIntervention
//        [HttpPut("PutFraisIntervention")]
//        public async Task<FraisIntervention> PutFraisIntervention([FromBody] FraisIntervention FraisIntervention) =>
//           await (new PutGenericHandler<FraisIntervention>(repository)).Handle(new PutGenericCommand<FraisIntervention>(FraisIntervention), new CancellationToken());
//        #endregion

//        #region Remove Function
//        // DELETE: api/FraisIntervention/5
//        [HttpDelete("DeleteFraisIntervention")]
//        public async Task<FraisIntervention> DeleteFraisIntervention(Guid id) =>
//           await (new RemoveGenericHandler<FraisIntervention>(repository)).Handle(new RemoveGenericCommand<FraisIntervention>(id), new CancellationToken());
//        #endregion
//    }
//} ( Hatem )
