using System.ComponentModel;
using TGW.Core.Models.Configuration.Types;

namespace TGW.Core.Models.Configuration;

/// <summary>
/// Power supply configuration
/// </summary>
public class PowerSupplyConfiguration
{
    /// <summary>
    /// System Power Supply (normal/big)
    /// </summary>
    [DisplayName("powerSupply")]
    public PowerSupplyType? PowerSupplyType { get; set; }
}