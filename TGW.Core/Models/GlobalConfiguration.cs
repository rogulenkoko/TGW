using System.ComponentModel;
using TGW.Core.Models.Sections;

namespace TGW.Core.Models;

/// <summary>
/// Global configuration
/// </summary>
public class GlobalConfiguration
{
    /// <see cref="DataGenerationSection"/>
    public DataGenerationSection DataGenerationSection { get; set; }
    
    /// <see cref="SystemConfigSection"/>
    public SystemConfigSection SystemConfigSection { get; set; }
    
    /// <see cref="ShuttleSystemSection"/>
    public ShuttleSystemSection ShuttleSystemSection { get; set; }
    
    /// <summary>
    /// Configuration raw data
    /// </summary>
    public IDictionary<string, (object? value, Type? type)> СonfigurationData { get; set; }

    public void Show()
    {
        ShowConfiguration(DataGenerationSection.OrderProfileConfiguration);
        ShowConfiguration(DataGenerationSection.ShuttleSystemConfiguration);
        
        ShowConfiguration(SystemConfigSection.ResultsConfiguration);
        ShowConfiguration(SystemConfigSection.PowerSupplyConfiguration);
        
        ShowConfiguration(ShuttleSystemSection.StructureConfiguration);
    }

    private void ShowConfiguration<T>(T value) where T : class
    {
        foreach (var property in value.GetType().GetProperties())
        {
            var displayName = property.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>()
                .Single()
                .DisplayName;
            var propertyValue = property.GetValue(value) ?? "Error";
            Console.WriteLine($"{displayName} : {propertyValue}");
        }
    }
}