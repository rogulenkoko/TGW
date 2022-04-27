using System.ComponentModel;

namespace TGW.Core.Models.Configuration;

/// <summary>
/// Results configuration
/// </summary>
public class ResultsConfiguration
{
    /// <summary>
    /// Result-Tracking Start Time (hours:minutes:seconds)
    /// </summary>
    [DisplayName("resultStartTime")]
    public TimeSpan? ResultStartTime { get; set; }
    
    /// <summary>
    /// Result-Tracking Interval (m)
    /// </summary>
    [DisplayName("resultInterval")]
    public int? ResultInterval { get; set; }
}