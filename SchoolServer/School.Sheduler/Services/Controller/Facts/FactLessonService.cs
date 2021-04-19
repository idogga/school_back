using HarabaSourceGenerators.Common.Attributes;
using Microsoft.EntityFrameworkCore;
using School.Sheduler.Context;
using School.Sheduler.Context.Facts;
using School.Sheduler.Services.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Sheduler.Services.Controller.Facts
{
    public partial class FactLessonService : 
        IQueryHandler<GroupQuery<FactLesson>, GroupResult<FactLesson>>,
        IQueryHandler<InstanceQuery<FactLesson>, FactLesson>
    {
        [Inject]
        private readonly SchedulerContext _context;

        public async Task<GroupResult<FactLesson>> HandleAsync(GroupQuery<FactLesson> query)
        {
            var contextQuery = _context.Lessons;
            var totalAmount = await contextQuery.CountAsync();
            var items = await contextQuery.Take(query.Amount).Skip(query.Page).ToListAsync();
            return new GroupResult<FactLesson>
            {
                Items = items,
                TotalAmount = totalAmount
            };
        }

        public async Task<FactLesson> HandleAsync(InstanceQuery<FactLesson> query)
        {
            var lesson = await _context.Lessons.FirstOrDefaultAsync(x => x.Id == query.Id);
            if (lesson == default)
                throw new ApplicationException($"Не удалось найти урок по id {query.Id}");

            return lesson;
        }
    }
}
