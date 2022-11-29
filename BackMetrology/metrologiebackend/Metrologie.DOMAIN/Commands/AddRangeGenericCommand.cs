using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrologie.Domain.Commands
{
    public class AddRangeGenericCommand<TEntity> : IRequest<string> where TEntity : class
    {
        public AddRangeGenericCommand(List<TEntity> obj)
        {
            Obj = obj;
        }
        public List<TEntity> Obj { get; }
    }
}
