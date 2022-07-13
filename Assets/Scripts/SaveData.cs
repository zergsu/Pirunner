using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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

    public void Save()
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

        //foreach (LevelData item in data.level)
        //{
        //    Debug.Log(item.unlocked + " " + item.high1 + " " + item.high2 + " " + item.high3);

        //}
    }

    static public LevelData Load2(int lev)
    {
        //using StreamReader reader = new StreamReader(path);
        //string json = reader.ReadToEnd();

        //ScoreData data = JsonUtility.FromJson<ScoreData>(json);

        return scoreData.level[lev];
    }

    public void LoadLevelData(int level)
    {

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
