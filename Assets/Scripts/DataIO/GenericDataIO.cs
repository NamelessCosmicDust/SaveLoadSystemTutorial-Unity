using Newtonsoft.Json;
using System.IO;
using UnityEngine;

internal class GenericDataIO<T>
{
    private readonly string filePath;

    public GenericDataIO(string saveFileName = "GameData.json")
    {
        filePath = Path.Combine(Application.persistentDataPath, saveFileName);
    }

    public void SaveData(T data)
    {
        // Regular json serialization, but formatted for better readability.
        string formattedJsonData =
            JsonConvert.SerializeObject(data, Formatting.Indented);

        // Write the string above into a file on a disk.
        using StreamWriter writer = new(filePath);
        writer.Write(formattedJsonData);

        Debug.Log("Game saved.");
    }

    public T LoadData()
    {
        try
        {
            // Read the file.
            using StreamReader reader = new(filePath);
            string jsonData = reader.ReadToEnd();

            // Regular json de-serialization
            // and assignment back into the data class.
            T data = JsonConvert.DeserializeObject<T>(jsonData);

            Debug.Log("Game loaded.");
            return data;
        }
        catch
        {
            throw;
        }
    }
}
