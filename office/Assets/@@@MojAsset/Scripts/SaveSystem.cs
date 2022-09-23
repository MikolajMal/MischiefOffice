using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveLevelStats(SaveAndLoad saveAndLoad)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/levelsStats.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerStats playerStats = new PlayerStats(saveAndLoad);

        formatter.Serialize(stream, playerStats);
        stream.Close();
    }

    public static PlayerStats LoadLevelStats()
    {
        string path = Application.persistentDataPath + "/levelsStats.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerStats playarStats = formatter.Deserialize(stream) as PlayerStats;
            stream.Close();

            return playarStats;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
