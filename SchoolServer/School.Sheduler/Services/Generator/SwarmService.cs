namespace School.Sheduler.Services.Generator
{
    using System.Collections.Generic;

    using School.Database;
    using School.Sheduler.Context.Facts;
    using School.Sheduler.Context.Rules;
    using School.Sheduler.Context.Schedule;

    internal class SwarmService
    {
        private readonly RuleCheckerService _ruleChecker;

        private IReadOnlyList<Cabinete> _cabinetes;

        private IReadOnlyList<Class> _classes;

        private readonly IReadOnlyList<BaseRule> _rules;

        private IReadOnlyList<ScheduleLesson> _scheduleLessons;

        private int _seed;

        private IReadOnlyList<Subject> _subjects;

        private IReadOnlyList<Teacher> _teachers;

        public SwarmService(IReadOnlyList<Teacher> teachers, IReadOnlyList<Class> classes, IReadOnlyList<Subject> subjects,
            IReadOnlyList<Cabinete> cabinetes, IReadOnlyList<BaseRule> rules, IReadOnlyList<ScheduleLesson> scheduleLessons)
        {
            _teachers = teachers;
            _classes = classes;
            _subjects = subjects;
            _cabinetes = cabinetes;
            _rules = rules;
            _scheduleLessons = scheduleLessons;
            Result = new List<FactLesson>();
            _ruleChecker = new RuleCheckerService(_rules);
        }

        public bool CanGenerate { get; private set; }

        public List<FactLesson> Result { get; }

        public long Score => _ruleChecker.Score;

        public bool Success { get; private set; }

        public void Generate()
        {
            Result.Clear();
        }

        public void SetSeed(int seed)
        {
            _seed = seed;
        }
    }
}