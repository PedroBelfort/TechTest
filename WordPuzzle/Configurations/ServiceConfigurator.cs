using Microsoft.Extensions.DependencyInjection;
using WordPuzzle.Interfaces;
using WordPuzzle.Services;

namespace WordPuzzle.Configurations
{
    public class ServiceConfigurator
    {
        public IServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                    .AddTransient<IManipulatorService, ManipulatorService>()
                    .AddTransient<ISolverService, SolverService>()
                    .AddTransient<IFileService, FileService>()
                    .AddTransient<IValidatorService, ValidatorService>()
                    .BuildServiceProvider();
        }
    }
}
