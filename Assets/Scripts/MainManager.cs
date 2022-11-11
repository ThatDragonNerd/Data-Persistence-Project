using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }

    public string playerName;
    public string highScoreName;

    public int currentScore;
    public int highScore;
    


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    [System.Serializable]
    public class SaveData
    {
        public int highScore;
        public string highScoreName;
    
    }

    public void SaveHighScore(int currentScore, string playerName)
    {
        SaveData data = new SaveData();
        data.highScore = currentScore;
        data.highScoreName = playerName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath +"/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScoreName = data.highScoreName;
        }
    }
}
