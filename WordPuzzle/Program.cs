using WordPuzzle;
using WordPuzzle.Configurations;


var serviceConfigurator = new ServiceConfigurator();
var serviceProvider = serviceConfigurator.ConfigureServices();
var appRunner = new WordPuzzleAppRunner(serviceProvider);
appRunner.Run();