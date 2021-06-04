using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using System.Runtime.Serialization.Formatters.Binary;
public class DetaManager : MonoBehaviour
{
    private static DetaManager _instance = null;
    public static DetaManager instance { get { return _instance; } }

    public int playerHP = 3;
    public string currentScene = "level1";
    // Start is called before the first frame update
    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Save()
    {
        savedata saveData = new savedata();
        saveData.sceneName = currentScene;
        saveData.playerHP = playerHP;

        FileStream fileStream = File.Create(Application.persistentDataPath + "/save.dat");

        Debug.Log("历厘 颇老 积己");
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fileStream, saveData);
        fileStream.Close();
    }
    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/save.dat")==true)
        {
            FileStream fileStream = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);
            if (fileStream != null && fileStream.Length>0)
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                savedata savedata = (savedata)binaryFormatter.Deserialize(fileStream);
                playerHP = savedata.playerHP;
                UiManager.instance.PlayerHP();
                currentScene = savedata.sceneName;
                fileStream.Close();
            }
        }
    }
}
