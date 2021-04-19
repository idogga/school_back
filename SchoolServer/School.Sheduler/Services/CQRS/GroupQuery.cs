using School.Sheduler.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Sheduler.Services.CQRS
{
    public class GroupQuery<TResult> : IQuery<GroupResult<TResult>>
    {
        /// <summary>
        /// Колличество данных в запросе.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Отступ.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Строка поиска.
        /// </summary>
        public string SearchString { get; set; }

        /// <inheritdoc/>
        public Task<LogRecord> LogAssume()
        {
            var result = new LogRecord
            {
                Action = $"Поиск {SearchString}. Колличество {Amount}, отступ {Page}",
            };
            return Task.FromResult(result);
        }
    }

    public class GroupResult<TResult>
    {
        /// <summary>
        /// Колличество данных в запросе.
        /// </summary>
        public long TotalAmount { get; set; }

        public List<TResult> Items { get; set; }
    }
}
