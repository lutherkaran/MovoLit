using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;



public static class SaveSystem {

    public static void Save(int _currentScene) {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = UnityEngine.Application.persistentDataPath + "/Save.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        LevelData data = new LevelData(_currentScene);
        binaryFormatter.Serialize(stream,data);
        stream.Close();
    
    }
    public static LevelData Load() {
        String path = UnityEngine.Application.persistentDataPath + "/Save.fun";
        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            LevelData data = binaryFormatter.Deserialize(stream) as LevelData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("Sorry File Doesn't Exists: " + path);
            return null;
        }
    }


}
