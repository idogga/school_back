namespace School.Sheduler.Context.Rules
{
    public abstract class BaseRule
    {
        public string Id { get; set; }

        public RuleType RuleType { get; set; }
    }
}