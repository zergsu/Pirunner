using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    static private ScoreData scoreData;

    static private string path = "";
    static private string persistentPath = "";

    private void Awake()
    {
        SetPaths();
        if (File.Exists(path))
            Load();
        else
            CreateSave();

    }

    private void CreateSave()
    {
        Debug.Log("creating new save");
        scoreData = new ScoreData();
        for (int i = 0; i < 4; i++)
        {
            scoreData.level[i] = new LevelData();
        }
        scoreData.level[0].unlocked = true;
    }

    private void SetPaths()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }


    static public void Save()
    {
        string savePath = path;

        string json = JsonUtility.ToJson(scoreData);

        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
    }

    public void Load()
    {
        Debug.Log("Loading");
        using StreamReader reader = new StreamReader(path);
        string json = reader.ReadToEnd();

        scoreData = JsonUtility.FromJson<ScoreData>(json);
    }

    static public LevelData LoadLevelData(int lev)
    {
        return scoreData.level[lev];
    }

    static void SaveNewScore(float h1, float h2, float h3)
    {
        LevelData lev = scoreData.level[SceneManager.GetActiveScene().buildIndex - 1];
        lev.high1 = h1;
        lev.high2 = h2;
        lev.high3 = h3;
        Save();
    }

    static public void CheckScore(float newTime)
    {
        LevelData lev = scoreData.level[SceneManager.GetActiveScene().buildIndex - 1];

        if (newTime < lev.high3)
        {
            lev.high3 = lev.high2;
            if (newTime < lev.high2)
            {
                lev.high2 = lev.high1;
                if (newTime < lev.high1)
                {
                    lev.high1 = newTime;
                }
                else lev.high2 = newTime;
            }
            else lev.high3 = newTime;
            SaveNewScore(lev.high1, lev.high2, lev.high3);
        }
    }

    static public void UnlockNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex != 4)
        {
            scoreData.level[SceneManager.GetActiveScene().buildIndex].unlocked = true;
            Save();
        }

    }

}

[System.Serializable]
public class ScoreData
{
    public LevelData[] level = new LevelData[4];
}

[System.Serializable]
public class LevelData
{
    public bool unlocked;
    public float high1 = 100;
    public float high2 = 100;
    public float high3 = 100;
}
