using System.ComponentModel;
using TGW.Core.Models.Configuration.Types;

namespace TGW.Core.Models.Configuration;

/// <summary>
/// Shuttle system configuration
/// </summary>
public class ShuttleSystemConfiguration
{
    /// <summary>
    /// Inbound Strategy (random/optimized)
    /// </summary>
    [DisplayName("inboundStrategy")]
    public InboundStrategyType? InboundStrategy { get; set; }
}