namespace School.Sheduler.Context
{
    public record LogRecord
    {
        public string Id { get; init; }

        public string From { get; init; }

        public string To { get; init; }

        public string Action { get; init; }
    }
}
