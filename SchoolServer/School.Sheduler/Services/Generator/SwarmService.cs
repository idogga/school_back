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

    /// <summary>
    /// Сервис смены.
    /// </summary>
    internal class SwarmService
    {
        /// <summary>
        /// Сервис проверки расписания.
        /// </summary>
        private readonly RuleCheckerService _ruleChecker;

        /// <summary>
        /// Список кабинетов.
        /// </summary>
        private IReadOnlyList<Cabinete> _cabinetes;

        /// <summary>
        /// Список классов.
        /// </summary>
        private IReadOnlyList<Class> _classes;

        /// <summary>
        /// Список правил.
        /// </summary>
        private readonly IReadOnlyList<BaseRule> _rules;

        /// <summary>
        /// Сетка уроков.
        /// </summary>
        private IReadOnlyList<ScheduleLesson> _scheduleLessons;

        /// <summary>
        /// Сервис учебных планов.
        /// </summary>
        private IReadOnlyList<PlanClass> _planClasses;

        /// <summary>
        /// Список учителей.
        /// </summary>
        private IReadOnlyList<Teacher> _teachers;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public SwarmService(IReadOnlyList<Teacher> teachers, 
            IReadOnlyList<Class> classes, 
            IReadOnlyList<Cabinete> cabinetes, 
            IReadOnlyList<BaseRule> rules, 
            IReadOnlyList<ScheduleLesson> scheduleLessons, 
            IReadOnlyList<PlanClass> planClasses)
        {
            _teachers = teachers;
            _classes = classes;
            _cabinetes = cabinetes;
            _rules = rules;
            _scheduleLessons = scheduleLessons;
            _planClasses = planClasses;
            Result = new List<FactLesson>();
            _ruleChecker = new RuleCheckerService(_rules, Result);
        }

        /// <summary>
        /// Может ли сервис продолжать генерирование.
        /// </summary>
        public bool CanGenerate { get; private set; }

        /// <summary>
        /// Результат.
        /// </summary>
        public List<FactLesson> Result { get; }

        /// <summary>
        /// Колличество ошибок.
        /// </summary>
        public long Score => _ruleChecker.Score;

        // TODO: Задать максимальное колличество ошибок.
        public bool Success => Score < 1000;

        /// <summary>
        /// Запустить расчет.
        /// </summary>
        public void Generate()
        {
            Result.Clear();
            Class(_classes);
            _ruleChecker.CalculatePost();
        }

        /// <summary>
        /// Расчет классов.
        /// </summary>
        /// <param name="classes">Список классов.</param>
        private void Class(IReadOnlyList<Class> classes)
        {
            foreach (var clas in classes)
            {
                var plans = _planClasses.First(x => x.Class.Id == clas.Id).SubjectPlans;
                Plan(plans, clas.Id);
            }
        }

        /// <summary>
        /// Расчет планов.
        /// </summary>
        /// <param name="subjectPlans">Список планов.</param>
        /// <param name="classId">Идентификатор класса.</param>
        private void Plan(ICollection<SubjectPlan> subjectPlans, string classId)
        {
            foreach (var subjectPlan in subjectPlans)
            {
                for (var i = 0; i < subjectPlan.Count; i++)
                    Subject(subjectPlan.Subject, classId);
            }
        }

        /// <summary>
        /// Расчет предмета.
        /// </summary>
        /// <param name="subject">Предмет.</param>
        /// <param name="classId">Идентификатор класса.</param>
        private void Subject(Subject subject, string classId)
        {
            var teachers = _teachers.Where(x => x.Subjects.Any(x => x.Id == subject.Id)).ToList();
            Teacher(teachers, classId, subject.Id);
        }

        /// <summary>
        /// Расчет учителя.
        /// </summary>
        /// <param name="teachers">Список учителей.</param>
        /// <param name="classId">Идентификатор класса.</param>
        /// <param name="subjectId">Идентификатор предмета.</param>
        private void Teacher(IReadOnlyList<Teacher> teachers, string classId, string subjectId)
        {
            foreach (var teacher in teachers)
            {
                Cabinente(classId, teacher.Id, subjectId);
            }
        }

        /// <summary>
        /// Расчет кабинетов.
        /// </summary>
        /// <param name="classId">Идентификатор класса.</param>
        /// <param name="teacherId">Идентификатор учителя.</param>
        /// <param name="subjectId">Идентификатор предмета.</param>
        private void Cabinente(string classId, string teacherId, string subjectId)
        {
            foreach (var cabinete in _cabinetes)
            {
                Lesson(classId, teacherId, subjectId, cabinete.Id);
            }
        }

        /// <summary>
        /// Расчет урока.
        /// </summary>
        /// <param name="classId">Идентификатор класса.</param>
        /// <param name="teacherId">Идентификатор учителя.</param>
        /// <param name="subjectId">Идентификатор предмета.</param>
        /// <param name="cabinenteId">Идентификатор кабинета.</param>
        private void Lesson(string classId, string teacherId, string subjectId, string cabinenteId)
        {
            var scheduleLessons = _scheduleLessons.OrderBy(x => x.Day).ThenBy(x => x.StartTime).ToList();
            foreach (var lesson in scheduleLessons)
            {
                if(CanStop(classId, subjectId))
                    continue;

                // Занят кабинет
                if(Result.Any(x=>x.Lesson.Id == lesson.Id && x.Cabinete == cabinenteId))
                    continue;

                // Занят учитель
                if (Result.Any(x=>x.Lesson.Id == lesson.Id && x.TeacherId == teacherId))
                    continue;

                // Занят класс
                if (Result.Any(x => x.Lesson.Id == lesson.Id && x.ClassId == classId))
                    continue;

                Result.Add(GenerateLesson(classId, teacherId, subjectId, cabinenteId, lesson));
            }
        }

        /// <summary>
        /// Можно ли выполнить остановку.
        /// </summary>
        /// <param name="classId">Идентификатор класса.</param>
        /// <param name="subjectId">Идентификатор предмета.</param>
        /// <returns>Флаг продолжения.</returns>
        private bool CanStop(string classId, string subjectId)
        {
            var contains = Result.Count(x => x.SubjectId == subjectId && x.ClassId == classId);
            var expected = _planClasses.Where(x => x.Class.Id == classId).SelectMany(x => x.SubjectPlans).
                                        Where(x => x.Subject.Id == subjectId).Sum(x => x.Count);
            if (contains == expected)
                return true;

            return false;
        }

        /// <summary>
        /// Сгенерировать предмет.
        /// </summary>
        /// <param name="classId">Идентификатор класса.</param>
        /// <param name="teacherId">Идентификатор учителя.</param>
        /// <param name="subjectId">Идентификатор предмета.</param>
        /// <param name="cabineteId">Идентификатор кабинета.</param>
        /// <param name="lesson">Сетка урока.</param>
        /// <returns>Фактическое занятие.</returns>
        private FactLesson GenerateLesson(string classId, 
            string teacherId, 
            string subjectId,
            string cabineteId,
            ScheduleLesson lesson)
        {
            return new FactLesson
            {
                Id = Guid.NewGuid(),
                ClassId = classId,
                Lesson = lesson,
                SubjectId = subjectId,
                TeacherId = teacherId,
                Cabinete = cabineteId
            };
        }
    }
}