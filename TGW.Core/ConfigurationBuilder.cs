using System.ComponentModel;
using TGW.Core.Models;
using TGW.Core.Models.Configuration;
using TGW.Core.Models.Sections;

namespace TGW.Core;

/// <summary>
/// Configuration builder
/// </summary>
public class ConfigurationBuilder
{
    private IReadOnlyDictionary<string, string> configurationData;
    private GlobalConfiguration globalConfiguration;

    public ConfigurationBuilder(IReadOnlyDictionary<string, string> configurationData)
    {
        this.configurationData = configurationData;
        globalConfiguration = new GlobalConfiguration
        {
            СonfigurationData = new Dictionary<string, (object value, Type type)>(),
        };
    }

    public ConfigurationBuilder AddDataGenerationSection()
    {
        var orderProfileConfiguration = BuildConfiguration<OrderProfileConfiguration>();
        var shuttleSystemConfiguration = BuildConfiguration<ShuttleSystemConfiguration>();
        globalConfiguration.DataGenerationSection = new DataGenerationSection
        {
            OrderProfileConfiguration = orderProfileConfiguration,
            ShuttleSystemConfiguration = shuttleSystemConfiguration,
        };

        return this;
    }
    
    public ConfigurationBuilder AddSystemConfigSection()
    {
        var powerSupplyConfiguration = BuildConfiguration<PowerSupplyConfiguration>();
        var resultsConfiguration = BuildConfiguration<ResultsConfiguration>();
        globalConfiguration.SystemConfigSection = new SystemConfigSection
        {
            PowerSupplyConfiguration = powerSupplyConfiguration,
            ResultsConfiguration = resultsConfiguration,
        };

        return this;
    }
    
    public ConfigurationBuilder AddShuttleSystemSection()
    {
        var structureConfiguration = BuildConfiguration<StructureConfiguration>();
        globalConfiguration.ShuttleSystemSection = new ShuttleSystemSection
        {
            StructureConfiguration = structureConfiguration,
        };

        return this;
    }

    public GlobalConfiguration Build()
    {
        return globalConfiguration;
    }

    private T BuildConfiguration<T>() where T : class
    {
        var configuration = Activator.CreateInstance<T>();
        foreach (var property in typeof(T).GetProperties())
        {
            var displayName = property.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>()
                .Single()
                .DisplayName;
            var configExists = configurationData.TryGetValue(displayName, out var valueString);
            if (!configExists)
            {
                continue;
            }

            var propertyType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

            object? value = null;
            
            if (propertyType.IsEnum)
            {
                if (Enum.TryParse(propertyType, valueString, true, out var enumValue))
                {
                    value = enumValue;
                }
            } 
            else if (propertyType == typeof(TimeSpan))
            {
                value = TimeSpan.Parse(valueString);
            }
            else
            {
                value = Convert.ChangeType(valueString, propertyType);
            }
            
            property.SetValue(configuration, value);
            globalConfiguration.СonfigurationData[displayName] = (value, propertyType);
        }

        return configuration;
    }
}