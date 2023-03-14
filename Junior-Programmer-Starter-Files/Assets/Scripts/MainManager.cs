using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public Color TeamColor;

    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
    }

    void Awake()
    {   // This code enables you to access the MainManager object from any other script.  
        
        if (Instance != null)
        {   // start of new code
            Destroy(gameObject);
            return;
        }   // end of new code

        // You can now call MainManager.Instance from any other script 
        Instance = this;
        // marks the MainManager GameObject attached to this script not to be destroyed when the scene changes
        DontDestroyOnLoad(gameObject);

        LoadColor();

    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            TeamColor = data.TeamColor;
        }
    }

}
