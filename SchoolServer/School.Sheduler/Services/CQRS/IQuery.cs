using School.Sheduler.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Sheduler.Services.CQRS
{
    public interface IQuery<TResult>
    {
        Task<LogRecord> LogAssume();
    }


    public interface IQueryHandler<TQuery, TResult> 
        where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }

    public class InstanceQuery<TResult>: IQuery<TResult>
    {
        public Guid Id { get; set; }

        public Task<LogRecord> LogAssume()
        {
            throw new NotImplementedException();
        }
    }
}
