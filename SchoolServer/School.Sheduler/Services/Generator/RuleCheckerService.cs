namespace School.Sheduler.Services.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using School.Sheduler.Context.Facts;
    using School.Sheduler.Context.Rules;

    internal class RuleCheckerService
    {
        private readonly IReadOnlyList<BaseRule> _rules;

        private readonly List<FactLesson> _lessons;

        /// <summary>
        /// Сервис проверки счетов.
        /// </summary>
        /// <param name="rules">Все правила.</param>
        public RuleCheckerService(IReadOnlyList<BaseRule> rules, List<FactLesson> lessons)
        {
            _rules = rules;
            _lessons = lessons;
        }

        // TODO: Добавить логику расчета текущего счета.
        public long Score => _rules.Count;

        public void CalculatePost()
        {
            Console.WriteLine("Начало расчета текущего счета.");
            Thread.Sleep(2000);
            Console.WriteLine("Окончание расчета.");
        }
    }
}