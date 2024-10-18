using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;

internal class DataIO
{
    //private DataGetSet dataGetSet = new();
    private DataGetSet currentGameData = new();
    private DataGetSet savedGameData;

    private readonly string filePath =
        Path.Combine(Application.persistentDataPath, "GameData.json");

    public void SaveData(bool isNewSave = false)
    {
        currentGameData.GetData();
        if (!isNewSave) MergeData();

        // Regular json serialization, but formatted for better readability.
        string formattedJsonData =
            JsonConvert.SerializeObject(currentGameData, Formatting.Indented);

        // Write the string above into a file on a disk.
        using StreamWriter writer = new(filePath);
        writer.Write(formattedJsonData);

        Debug.Log("Game saved.");
    }

    public void LoadData(bool isCompleteLoad = true)
    {
        if (File.Exists(filePath))
        {
            try
            {
                // Read the file.
                using StreamReader reader = new(filePath);
                string jsonData = reader.ReadToEnd();

                // Regular json de-serialization
                if (isCompleteLoad)
                {
                    // Set current game data,
                    currentGameData =
                        JsonConvert.DeserializeObject<DataGetSet>(jsonData);

                    // This is default data load, thus sets the data.
                    currentGameData.SetData();

                    Debug.Log("Game loaded.");
                }
                else
                {
                    // - or pass it to data merge logic.
                    savedGameData = new();
                    savedGameData =
                        JsonConvert.DeserializeObject<DataGetSet>(jsonData);

                    // This is for data merge, so we don't set the data.
                    Debug.Log("Data prepared for merge.");
                }

            }
            catch
            {
                throw;
            }
        }
        else
        {
            Debug.LogWarning("Save file not found.");
        }
    }

    private void MergeData()
    {
        LoadData(false);

        // DataGetSet is the data type for this.
        Type type = typeof(DataGetSet);

        // For each property in DataGetSet type data,
        FieldInfo[] fields = type.GetFields();

        foreach (FieldInfo field in fields)
        {
            // - get the value of it. Do this for both the current and saved data for comparison.
            object currentValue = field.GetValue(currentGameData);
            object savedValue = field.GetValue(savedGameData);

            if ((currentValue == null) && (savedValue != null))
            {
                // If currentValue is null, savedValue is not, this is in the past.
                // Merge savedValue to keep previous progress.
                field.SetValue(currentGameData, savedValue);

                Debug.Log($"Set {savedValue} to {currentGameData}");
            }
            else
            {
                // In the other three cases, the currentValue will stay.
                continue;
            }
        }
    }
}
