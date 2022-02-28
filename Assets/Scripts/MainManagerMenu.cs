using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManagerMenu : MonoBehaviour
{
    public static MainManagerMenu Instance;
    public int HighScore;
    public string PlayerName;
    public string HighScorePlayerName;

    private void Awake()
    {
        // singleton implementation
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // real stuff
        LoadHighScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string HighScorePlayerName;
        public int HighScore;
    }

    public void SaveHighScore()
    {
        var data = new SaveData();
        data.HighScorePlayerName = MainManagerMenu.Instance.PlayerName;
        data.HighScore = HighScore;

        var json = JsonUtility.ToJson(data);

        File.WriteAllText($"{Application.persistentDataPath}/savefile.json", json);
    }

    public void LoadHighScore()
    {
        var path = $"{Application.persistentDataPath}/savefile.json";
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<SaveData>(json);

            HighScorePlayerName = data.HighScorePlayerName;
            HighScore = data.HighScore;

        }
        else
        {
            HighScorePlayerName = "N/A";
            HighScore = 0;
        }
    }

    public void UpdateHighScore(string newHighScorePlayerName, int newHighScore)
    {
        HighScorePlayerName = newHighScorePlayerName;
        HighScore = newHighScore;
        SaveHighScore();
    }


}
