namespace School.Sheduler.Services.Generator
{
    using System.Collections.Generic;

    using School.Sheduler.Context.Rules;

    internal class RuleCheckerService
    {
        private readonly IReadOnlyList<BaseRule> _rules;

        public RuleCheckerService(IReadOnlyList<BaseRule> rules)
        {
        }

        public long Score { get; set; }
    }
}