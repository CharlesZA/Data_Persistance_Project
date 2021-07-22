using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class GameData : MonoBehaviour
{

    public static GameData Instance;

    public string currentPlayerName;
    public string bestPlayerName;
    public int bestPlayerScore;

    [System.Serializable]
    class SavedData
    {
        public string bestPlayerName;
        public int bestPlayerScore;
    }


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadData();
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/gamedata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavedData data = JsonUtility.FromJson<SavedData>(json);

            bestPlayerName = data.bestPlayerName;
            bestPlayerScore = data.bestPlayerScore;

        }
    }

    public void SaveData()
    {
        SavedData data = new SavedData();
        data.bestPlayerName = bestPlayerName;
        data.bestPlayerScore = bestPlayerScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/gamedata.json", json);

    }
}