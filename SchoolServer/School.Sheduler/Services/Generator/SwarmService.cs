namespace School.Sheduler.Services.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;

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

        private IReadOnlyList<PlanClass> _planClasses;

        private int _seed;

        private IReadOnlyList<Subject> _subjects;

        private IReadOnlyList<Teacher> _teachers;

        public SwarmService(IReadOnlyList<Teacher> teachers, IReadOnlyList<Class> classes, IReadOnlyList<Subject> subjects,
            IReadOnlyList<Cabinete> cabinetes, IReadOnlyList<BaseRule> rules, IReadOnlyList<ScheduleLesson> scheduleLessons, IReadOnlyList<PlanClass> planClasses)
        {
            _teachers = teachers;
            _classes = classes;
            _subjects = subjects;
            _cabinetes = cabinetes;
            _rules = rules;
            _scheduleLessons = scheduleLessons;
            _planClasses = planClasses;
            Result = new List<FactLesson>();
            _ruleChecker = new RuleCheckerService(_rules, Result);
        }

        public bool CanGenerate { get; private set; }

        public List<FactLesson> Result { get; }

        public long Score => _ruleChecker.Score;

        // TODO: Задать максимальное колличество ошибок.
        public bool Success => Score < 1000;

        public void Generate()
        {
            Result.Clear();
            Class(_classes);
            _ruleChecker.CalculatePost();
        }

        private bool CanStop()
        {
            var isAllClassUses = Result.Select(x => x.ClassId).Distinct().Count() == _classes.Count;
            if (!isAllClassUses)
                return false;

            var isPlansUses = Result.Select(x => x.SubjectId).Distinct().Count() ==
                              _planClasses.SelectMany(x => x.SubjectPlans).Sum(x => x.Count);
            if (!isPlansUses)
                return false;


            return true;
        }

        public void SetSeed(int seed)
        {
            _seed = seed;
        }

        private void Class(IReadOnlyList<Class> classes)
        {
            foreach (var clas in classes)
            {
                var plans = _planClasses.First(x => x.Class.Id == clas.Id).SubjectPlans;
                Plan(plans, clas.Id);
            }
        }

        private void Plan(ICollection<SubjectPlan> subjectPlans, string classId)
        {
            foreach (var subjectPlan in subjectPlans)
            {
                for (var i = 0; i < subjectPlan.Count; i++)
                    Subject(subjectPlan.Subject, classId);
            }
        }

        private void Subject(Subject subject, string classId)
        {
            var teachers = _teachers.Where(x => x.Subjects.Any(x => x.Id == subject.Id)).ToList();
            Teacher(teachers, classId, subject.Id);
        }

        private void Teacher(IReadOnlyList<Teacher> teachers, string classId, string subjectId)
        {
            foreach (var teacher in teachers)
            {
                Cabinente(classId, teacher.Id, subjectId);
            }
        }

        private void Cabinente(string classId, string teacherId, string subjectId)
        {
            foreach (var cabinete in _cabinetes)
            {
                Lesson(classId, teacherId, subjectId, cabinete.Id);
            }
        }

        private void Lesson(string classId, string teacherId, string subjectId, string cabinenteId)
        {
            var currentDay = Result.Any() ? Result.Select(x => x.Lesson.Day).Max() : _scheduleLessons.Select(x => x.Day).Min();
            if (Result.Count(x => x.Lesson.Day == currentDay) == 8)
                currentDay = GetNextDay(currentDay);

            if(CanStop())
                return;
            
            var scheduleLessons = _scheduleLessons.Where(x => x.Day == currentDay).ToList();
            foreach (var lesson in scheduleLessons)
            {
                Result.Add(GenerateLesson(classId, teacherId, subjectId, cabinenteId, lesson));
                return;
            }

            Result.Add(GenerateEmpty());
        }

        private DayOfWeek GetNextDay(DayOfWeek currentDay)
        {
            var availableDates = _scheduleLessons.Select(x => x.Day).Distinct().ToList();
            if (currentDay < availableDates.Max())
                return currentDay + 1;

            return availableDates.Min();
        }

        private FactLesson GenerateLesson(string classId, 
            string teacherId, 
            string subjectId,
            string cabineteId,
            ScheduleLesson lesson)
        {
            return new FactLesson
            {
                ClassId = classId,
                Lesson = lesson,
                SubjectId = subjectId,
                TeacherId = teacherId,
                Cabinete = cabineteId
            };
        }

        private FactLesson GenerateEmpty()
        {
            return null;
        }
    }
}