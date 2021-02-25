using System.Threading.Tasks;

namespace School.Sheduler.Services.Controller
{
    using School.Sheduler.Services.Generator;

    public class SchedullerGeneratorService
    {
        private readonly GeneratorService _generatorService;

        public SchedullerGeneratorService(GeneratorService generatorService)
        {
            _generatorService = generatorService;
        }

        public async Task LoadAndSaveAsync()
        {
            await _generatorService.Start();
        }
    }
}
