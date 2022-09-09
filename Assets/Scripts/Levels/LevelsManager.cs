using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public static class LevelsManager
{
    public static Level[] levels;

    public static void Save()
    {
        //savedGames.Add(Game.current);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create (Application.persistentDataPath + "/levelsData.data");
        bf.Serialize(file, LevelsManager.levels);
        file.Close();
    }
    public static void Load() {
        if(File.Exists(Application.persistentDataPath + "/levelsData.data")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/levelsData.data", FileMode.Open);
            LevelsManager.levels = (Level[])bf.Deserialize(file);
            file.Close();
        }
        else
        {
            Init();
        }
    }

    public static void Init()
    {
        levels = new Level[999];
        for (int i = 0; i < 999; i++)
        {
            levels[i] = new Level();
            
        }
        levels[0].Locked = false;
    }

    public static void LevelComplete(int id)
    {
        levels[id].Completed = true;
        UnlockNewLevel();
    }
    public static void LevelComplete(int id, int stars)
    {
        levels[id].Completed = true;
        levels[id].Stars = stars;
        UnlockNewLevel();
    }

    private static void UnlockNewLevel()
    {
        foreach (var lvl in levels)
        {
            if (lvl.Locked == true)
            {
                lvl.Unlock();
                break;
            }
        }
    }
    

}
