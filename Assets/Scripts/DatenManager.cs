using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DatenManager : MonoBehaviour
{
    public static DatenManager Instance;

    public int bestscore;
    public string Name;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScoreandName();
    }


    [System.Serializable]
    class SaveData
    {
        public int bestscore;
        public string Name;
    }

    public void SaveScoreandName()
    {
        SaveData data = new SaveData();
        data.bestscore = bestscore;
        data.Name = Name;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScoreandName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestscore = data.bestscore;
            Name = data.Name;
        }
    }


    public void SetMyName(string Name)
    {
        DatenManager.Instance.Name = Name;
    }

    public void writeBestScore(int bestscore)
    {
        DatenManager.Instance.bestscore = bestscore;

    }
}
    