using MediatR;
using Metrologie.Domain.Commands;
using Metrologie.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Metrologie.Domain.Handlers
{
    public class PostRangeGenenricHandler<TEntity> : IRequestHandler<AddRangeGenericCommand<TEntity>, string> where TEntity : class
    {

        private readonly IGenericRepository<TEntity> repository;
        public PostRangeGenenricHandler(IGenericRepository<TEntity> Repository)
        {
            repository = Repository;
        }
        public Task<string> Handle(AddRangeGenericCommand<TEntity> request, CancellationToken cancellationToken)
        {
            var result = repository.AddRange(request.Obj);
            return Task.FromResult(result);
        }
    }
}
