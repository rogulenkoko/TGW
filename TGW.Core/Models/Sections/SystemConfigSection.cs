using TGW.Core.Models.Configuration;

namespace TGW.Core.Models.Sections;

public class SystemConfigSection
{
    /// <see cref="PowerSupplyConfiguration"/>
    public PowerSupplyConfiguration PowerSupplyConfiguration { get; set; }
    
    /// <see cref="ResultsConfiguration"/>
    public ResultsConfiguration ResultsConfiguration { get; set; }
}