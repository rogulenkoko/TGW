using System.ComponentModel;

namespace TGW.Core.Models.Configuration;

/// <summary>
/// Structure configuration
/// </summary>
public class StructureConfiguration
{
    /// <summary>
    /// The number of shuttle aisles in the system
    /// </summary>
    [DisplayName("numberOfAisles")]
    public int? NumberOfAisles { get; set; }
}