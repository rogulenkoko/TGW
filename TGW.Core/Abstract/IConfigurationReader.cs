namespace TGW.Core.Abstract;

/// <summary>
/// Configuration reader
/// </summary>
public interface IConfigurationReader
{
    /// <summary>
    /// Read configuration
    /// </summary>
    /// <param name="fileName">File name</param>
    /// <returns>List of all configurations in the file (name - value)</returns>
    IReadOnlyDictionary<string, string> ReadConfiguration(string fileName);
}