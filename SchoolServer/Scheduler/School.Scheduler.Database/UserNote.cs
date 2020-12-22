namespace School.Scheduler.Database
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class UserNote : BaseEntity
    {
        public DateTime? EndDate { get; set; }

        public ICollection<SchedulerNote> Notes { get; set; }

        public DateTime StartDate { get; set; }

        public string StartUserId { get; set; }

        public static UserNote CreateIndexOperation(string id, string userId, DateTime start, DateTime? end,
            IEnumerable<SchedulerNote> notes)
        {
            var collection = new Collection<SchedulerNote>();
            foreach (var note in notes)
            {
                collection.Add(note);
            }

            return new UserNote
            {
                Id = id,
                StartUserId = userId,
                StartDate = start,
                EndDate = end,
                Notes = collection
            };
        }
    }
}