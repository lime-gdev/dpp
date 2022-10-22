using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;

    public int Score;
    public string Name;
    public string BestName;

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
    [System.Serializable]
    private class SaveData
    {

        public string BestName;
        public int Score;

    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.BestName = Name;
        data.Score = Score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestName = data.BestName;
            Score = data.Score;
        }
    }
}
