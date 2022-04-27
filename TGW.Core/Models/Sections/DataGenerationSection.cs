using TGW.Core.Models.Configuration;

namespace TGW.Core.Models.Sections;

/// <summary>
/// Data generation section
/// </summary>
public class DataGenerationSection
{
    /// <see cref="OrderProfileConfiguration"/>
    public OrderProfileConfiguration OrderProfileConfiguration { get; set; }
    
    /// <see cref="ShuttleSystemConfiguration"/>
    public ShuttleSystemConfiguration ShuttleSystemConfiguration { get; set; }
}