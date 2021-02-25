namespace School.Sheduler.Services.Generator
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using School.Database;
    using School.Sheduler.Context;
    using School.Sheduler.Context.Facts;
    using School.Sheduler.Context.Rules;
    using School.Sheduler.Context.Schedule;

    public class GeneratorService
    {
        private readonly ConcurrentQueue<ResultCell> _queue;

        private readonly SchedulerContext _schedulerContext;

        private readonly SchoolContext _schoolContext;

        private IReadOnlyList<Cabinete> _cabinetes;

        private IReadOnlyList<Class> _classes;

        private IReadOnlyList<BaseRule> _rules;

        private IReadOnlyList<ScheduleLesson> _scheduleLessons;

        private IReadOnlyList<Subject> _subjects;
        private IReadOnlyList<PlanClass> _plans;

        private IReadOnlyList<Teacher> _teachers;

        public GeneratorService(SchedulerContext schedulerContext,
            SchoolContext schoolContext)
        {
            _schedulerContext = schedulerContext;
            _schoolContext = schoolContext;
            _queue = new ConcurrentQueue<ResultCell>();
        }

        /// <summary>
        /// Начать обработку.
        /// </summary>
        /// <returns></returns>
        public async Task Start()
        {
            var maxLessonsCount = await GetMaxLessonsCountAsync();
            _teachers = await _schoolContext.Teachers.AsNoTracking().Include(x=>x.Subjects).Include(x=>x.Subjects).ToListAsync();
            _classes = await _schoolContext.Classes.AsNoTracking().ToListAsync();
            _subjects = await _schoolContext.Subjects.AsNoTracking().ToListAsync();
            _cabinetes = await _schoolContext.Cabinetes.AsNoTracking().ToListAsync();
            _plans = await _schoolContext.PlanClasses.AsNoTracking().Include(x=>x.Class).Include(x=>x.SubjectPlans).ThenInclude(x=>x.Subject).ToListAsync();
            _scheduleLessons = await _schedulerContext.ScheduleLessons.AsNoTracking().ToListAsync();
            var rules = new List<BaseRule>();
            var classRules = await _schedulerContext.ClassRules.AsNoTracking().ToListAsync();
            var subjectRules = await _schedulerContext.SubjectRules.AsNoTracking().ToListAsync();
            var teacherRules = await _schedulerContext.TeacherRules.AsNoTracking().ToListAsync();
            rules.AddRange(classRules);
            rules.AddRange(subjectRules);
            rules.AddRange(teacherRules);
            _rules = new List<BaseRule>();

            //Parallel.For(0, maxLessonsCount, StartLoading);
            StartLoading(0, null);
        }

        private Task<int> GetMaxLessonsCountAsync()
        {
            return _schedulerContext.ScheduleLessons.GroupBy(x => x.Day).Select(x => x.Count()).MaxAsync();
        }

        private void Load(SwarmService swarmService, int seed)
        {
            swarmService.SetSeed(seed);
            swarmService.Generate();

            if (swarmService.Success)
                _queue.Enqueue(new ResultCell(swarmService.Score, swarmService.Result));

            if (swarmService.CanGenerate)
                Load(swarmService, ++seed);
        }

        private void StartLoading(int startHour, ParallelLoopState state)
        {
            var swarmService = new SwarmService(_teachers, _classes, _subjects, _cabinetes, _rules, _scheduleLessons, _plans);
            Load(swarmService, 0);
        }

        /// <summary>
        /// Ячейка с предварительным результатом.
        /// </summary>
        private struct ResultCell
        {
            /// <summary>
            /// Конструктор.
            /// </summary>
            public ResultCell(long score, List<FactLesson> lessons)
            {
                Score = score;
                Lessons = lessons;
            }

            /// <summary>
            /// Список уроков.
            /// </summary>
            public List<FactLesson> Lessons { get; }

            /// <summary>
            /// Текущий счет.
            /// </summary>
            public long Score { get; }
        }
    }
}