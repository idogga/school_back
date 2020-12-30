namespace School.Scheduler.Database
{
    using System;
    using System.CodeDom.Compiler;

    public class Penalty: BaseEntity
    {
        public PenaltyType PenaltyType { get; set; }

        public string Description { get; set; }

        public static Penalty Generate(string description, PenaltyType type, string id = null)
        {
            return new Penalty
            {
                Id = string.IsNullOrEmpty(id) ? Guid.NewGuid().ToString() : id,
                Description = description,
                PenaltyType = type
            };
        }
    }
}
