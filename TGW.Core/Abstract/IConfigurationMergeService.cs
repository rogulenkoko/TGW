namespace TGW.Core.Abstract;

/// <summary>
/// Service for configuration merge
/// </summary>
public interface IConfigurationMergeService
{
    /// <summary>
    /// Merge two configurations
    /// </summary>
    Dictionary<string, string> Merge(IReadOnlyDictionary<string, string> configuration,
        IReadOnlyDictionary<string, string> newConfiguration);
}