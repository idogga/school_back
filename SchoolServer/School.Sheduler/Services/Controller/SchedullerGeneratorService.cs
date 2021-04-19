using System.Threading.Tasks;

namespace School.Sheduler.Services.Controller
{
    using HarabaSourceGenerators.Common.Attributes;
    using School.Sheduler.Services.Generator;

    public interface ISchedulerGeneratorService
    {
        Task LoadAndSaveAsync();
    }

    public partial class SchedullerGeneratorService : ISchedulerGeneratorService
    {
        [Inject]
        private readonly GeneratorService _generatorService;

        public async Task LoadAndSaveAsync()
        {
            await _generatorService.Start();
        }
    }
}
