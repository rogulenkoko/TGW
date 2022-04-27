using TGW.Core.Abstract;

namespace TGW.Data;

public class FileConfigurationReader : IConfigurationReader
{
    public IReadOnlyDictionary<string, string> ReadConfiguration(string fileName)
    {
        var configurationData = new Dictionary<string, string>();
        var configurationDataString = File.ReadAllText(fileName);
        var nameSeparator = ":\t";
        var valueSeparator = "\t";
        foreach (var line in configurationDataString.Split("\n"))
        {
            if (line.IndexOf(nameSeparator, StringComparison.InvariantCulture) < 0)
            {
                continue;
            }

            var lineData = line.Split(nameSeparator);
            if (lineData.Length < 2)
            {
                continue;
            }
            
            var name = lineData[0];
            var value = lineData[1].Trim().Split(valueSeparator)[0];
            var operationResult = configurationData.TryAdd(name, value);
            if (!operationResult)
            {
                Console.WriteLine($"Ivalid configuration file. {fileName}");
            }
        }

        return configurationData;
    }
}