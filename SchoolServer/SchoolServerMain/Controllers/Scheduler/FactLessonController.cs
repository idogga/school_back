using Microsoft.AspNetCore.Mvc;
using School.Sheduler.Context.Facts;
using School.Sheduler.Services.Controller;
using School.Sheduler.Services.CQRS;
using System;
using System.Threading.Tasks;

namespace SchoolServerMain.Controllers.Scheduler
{
    public abstract class TestLessonController<T>: ControllerBase
    {
        [HttpGet]
        public virtual Task<T> ReadAsync([FromServices] IQueryHandler<InstanceQuery<T>, T> handler, 
            [FromQuery] Guid id)
        {
            var query = new InstanceQuery<T>()
            {
                Id = id
            };

            return handler.HandleAsync(query);
        }

        [HttpPost]
        public virtual Task<GroupResult<T>> ListAsync([FromServices] IQueryHandler<GroupQuery<T>, GroupResult<T>> handler,
            [FromQuery] int amount, [FromQuery] int page, [FromQuery] string search)
        {
            var query = new GroupQuery<T>()
            {
                Amount = amount,
                Page = page,
                SearchString = search
            };

            return handler.HandleAsync(query);
        }
    }

    [Route("api/[controller]")]
    public class FactLessonController : TestLessonController<FactLesson>
    {

        [HttpGet("generate")]
        public Task GenerateAsync([FromServices] ISchedulerGeneratorService generateService)
        {
            return generateService.LoadAndSaveAsync();
        }
    }
}
