using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    static private ScoreData scoreData;
    private LevelData test = new LevelData();

    static private string path = "";
    private string persistentPath = "";

    private void Awake()
    {
        SetPaths();
        if (File.Exists(path))
            Load();
        else
            CreateSave();

    }
    private void Start()
    {

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            Save();

        if (Input.GetKeyDown(KeyCode.I))
            Load();
    }

    static public void Save()
    {
        string savePath = path;

        Debug.Log("Saving Data at " + savePath);
        string json = JsonUtility.ToJson(scoreData);
        Debug.Log(json);

        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
    }

    public void Load()
    {
        Debug.Log("Loading");
        using StreamReader reader = new StreamReader(path);
        string json = reader.ReadToEnd();

        scoreData = JsonUtility.FromJson<ScoreData>(json);

        //log loaded items
        //foreach (LevelData item in scoreData.level[0])
        //{
        Debug.Log(scoreData.level[0].unlocked + " " + scoreData.level[0].high1 + " " + scoreData.level[0].high2 + " " + scoreData.level[0].high3);

        //}
    }

    static public LevelData Load2(int lev)
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

    //unlocks the next level
    static public void UnlockNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex != 4)
            scoreData.level[SceneManager.GetActiveScene().buildIndex].unlocked = true;
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
    public float high1;
    public float high2;
    public float high3;
}
