using TGW.Core.Abstract;

namespace TGW.Core.Services;

/// <inheritdoc />
public class ConfigurationMergeService : IConfigurationMergeService
{
    public Dictionary<string, string> Merge(IReadOnlyDictionary<string, string> configuration, IReadOnlyDictionary<string, string> newConfiguration)
    {
        var resultConfiguration = new Dictionary<string, string>(configuration);
        foreach (var newConfigurationKey in newConfiguration.Keys)
        {
            resultConfiguration[newConfigurationKey] = newConfiguration[newConfigurationKey];
        }
        
        return resultConfiguration;
    }
}