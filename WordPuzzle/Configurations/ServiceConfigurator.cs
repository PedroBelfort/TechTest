using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
