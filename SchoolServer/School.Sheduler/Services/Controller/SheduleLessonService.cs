namespace School.Sheduler.Services.Controller
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using School.Sheduler.Context;
    using School.Sheduler.Context.Schedule;

    public class SheduleLessonService
    {
        private readonly SchedulerContext _context;

        public async Task<Guid> AddAsync(ScheduleLesson lesson)
        {
            ThrowIfNotValidate(lesson);
            await ThrowIdCantInsertAsync(lesson);
            var id = Guid.NewGuid();
            lesson.Id = id;
            _context.Add(lesson);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task DeleteAsync(Guid lessonId)
        {
            var lesson = await _context.ScheduleLessons.FirstOrDefaultAsync(x => x.Id == lessonId);
            if (lesson == default) throw new ApplicationException("Не найден");

            _context.Remove(lesson);
            await _context.SaveChangesAsync();
        }

        private async Task ThrowIdCantInsertAsync(ScheduleLesson lesson)
        {
            var actuaLessons = await _context.ScheduleLessons.Where(x => x.Day == lesson.Day).ToListAsync();
            if (actuaLessons.Any(x => x.StartTime >= lesson.StartTime && x.EndTime <= lesson.StartTime))
                throw new ApplicationException("Время начала не совпадает");

            if (actuaLessons.Any(x => x.StartTime >= lesson.EndTime && x.EndTime <= lesson.EndTime))
                throw new ApplicationException("Время окончания не совпадает");

            if (actuaLessons.Any(x => x.StartTime < lesson.StartTime && x.EndTime > lesson.EndTime))
                throw new ApplicationException("Временной промежуток не совпадает");
        }

        private void ThrowIfNotValidate(ScheduleLesson lesson)
        {
            if (lesson.StartTime >= lesson.EndTime)
                throw new ApplicationException($"Дата начала урока [{lesson.StartTime}] больше окончания [{lesson.EndTime}]");
        }
    }
}