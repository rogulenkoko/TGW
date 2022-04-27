using System.ComponentModel;

namespace TGW.Core.Models.Configuration;

/// <summary>
/// Order profile configuration
/// </summary>
public class OrderProfileConfiguration
{
    /// <summary>
    /// Number of Orders per Hour
    /// </summary>
    [DisplayName("ordersPerHour")]
    public int? OrdersPerHour { get; set; }
    
    /// <summary>
    /// Number of Order-Lines per Order
    /// </summary>
    [DisplayName("orderLinesPerOrder")]
    public int? OrderLinesPerOrder { get; set; }
}