using MediatR;
using Metrologie.Domain.Interfaces;
using Metrologie.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Metrologie.Domain.Handlers
{
    public class GetListGenericHandler<TEntity> : IRequestHandler<GetListGenericQuery<TEntity>, IEnumerable<TEntity>> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> repository;
        public GetListGenericHandler(IGenericRepository<TEntity> Repository)
        {
            this.repository = Repository;
        }

        public Task<IEnumerable<TEntity>> Handle(GetListGenericQuery<TEntity> request, CancellationToken cancellationToken)
        {
            var result = repository.GetList(request.Condition, request.Includes);
            return Task.FromResult(result);
        }
    }
}
