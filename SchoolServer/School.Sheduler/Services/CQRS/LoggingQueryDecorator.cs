using HarabaSourceGenerators.Common.Attributes;
using School.Sheduler.Context;
using System.Threading.Tasks;

namespace School.Sheduler.Services.CQRS
{
    //public partial class LoggingQueryDecorator<TQuery, TResult>
    //    : IQueryHandler<TQuery, TResult>
    //    where TQuery : IQuery<TResult>
    //{
    //    [Inject]
    //    private readonly IQueryHandler<TQuery, TResult> _decoratedService;


    //    [Inject]
    //    private readonly SchedulerContext _context;

    //    public async Task<TResult> HandleAsync(TQuery query)
    //    {
    //        var logRecord = await query.LogAssume();
    //        if (logRecord != default)
    //        {
    //            _context.Add(logRecord);
    //            await _context.SaveChangesAsync();
    //        }

    //        return await _decoratedService.HandleAsync(query);            
    //    }
    //}
}
