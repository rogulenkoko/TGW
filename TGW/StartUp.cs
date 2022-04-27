using TGW.Core;
using TGW.Core.Abstract;
using TGW.Core.Models;

namespace TGW;

internal class StartUp
{
    private readonly IConfigurationReader reader;
    private readonly IConfigurationMergeService configurationMergeService;

    public StartUp(IConfigurationReader reader,
        IConfigurationMergeService configurationMergeService)
    {
        this.reader = reader;
        this.configurationMergeService = configurationMergeService;
    }

    public void Run()
    {
        var coreDirectory = Directory.GetCurrentDirectory();
        var configurationFiles = Directory.GetFiles($"{coreDirectory}/Configuration");

        var allConfigurations = new Dictionary<string, GlobalConfiguration>();
        var globalMergedConfigurationData = new Dictionary<string, string>();
        foreach (var configurationFile in configurationFiles)
        {
            var configurationData = reader.ReadConfiguration(configurationFile);
            globalMergedConfigurationData = configurationMergeService.Merge(globalMergedConfigurationData, configurationData);
            
            var builder = new ConfigurationBuilder(configurationData);

            var globalConfiguration = builder.AddDataGenerationSection()
                .AddShuttleSystemSection()
                .AddSystemConfigSection()
                .Build();
            
            Console.WriteLine(configurationFile);
            globalConfiguration.Show();
            Console.WriteLine();
            
            allConfigurations.Add(configurationFile, globalConfiguration);
        }
        
        var mergedBuilder = new ConfigurationBuilder(globalMergedConfigurationData);
        
        var globalMergedConfiguration = mergedBuilder.AddDataGenerationSection()
            .AddShuttleSystemSection()
            .AddSystemConfigSection()
            .Build();
        
        Console.WriteLine("Merged");
        globalMergedConfiguration.Show();

        Console.ReadKey();
    }
}