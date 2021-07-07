using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]

public class SaveData
{
    public string highScoreName1;
    public string highScoreName2;
    public string highScoreName3;
    public string highScoreName4;
    public string highScoreName5;

    public int highScore1;
    public int highScore2;
    public int highScore3;
    public int highScore4;
    public int highScore5;

    public string localName;

    public SaveData(MainManager mainManager)
    {
        highScoreName1 = mainManager.highScoreName1;
        highScoreName2 = mainManager.highScoreName2;
        highScoreName3 = mainManager.highScoreName3;
        highScoreName4 = mainManager.highScoreName4;
        highScoreName5 = mainManager.highScoreName5;

        highScore1 = mainManager.highScore1;
        highScore2 = mainManager.highScore2;
        highScore3 = mainManager.highScore3;
        highScore4 = mainManager.highScore4;
        highScore5 = mainManager.highScore5;

        localName = mainManager.localName;
    }
}

public static class SaveSystem
{
    public static void SaveData(MainManager mainManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/SaveData";
        FileStream stream = new FileStream(path, FileMode.Create);
        SaveData data = new SaveData(mainManager);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData LoadData()
    {
        string path = Application.persistentDataPath + "/SaveData";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("File was not found in " + path);
            return null;
        }
    }
}
