using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public string name;
    public int gold;
    public int tapgold;
    public int currentswordlevel;
    public int Gsuccesschancelevel;
    public SaveData(string _name, int _gold, int _tapgold, int _currentswordlevel, int _Gsuccesschancelevel)
    {
        name = _name;
        gold = _gold;
        tapgold = _tapgold;
        currentswordlevel = _currentswordlevel;
        Gsuccesschancelevel = _Gsuccesschancelevel;
    }
}
public static class SaveSystem // save location -> C:\Users\{username}\AppData\LocalLow\{addition_location}
{
    public static string SavePath => Application.persistentDataPath + "/saves/";
    private static string encryptionCodeWord = "SoloGame";
    // private static bool useEncryption = true;


    public static void Save(SaveData saveData, string saveFileName ,bool useEncryption)
    {
        if (!Directory.Exists(SavePath)) // �������� ������ ���� ������ش�.
        {
            Directory.CreateDirectory(SavePath);
        }

        string saveJson = JsonUtility.ToJson(saveData);
        if(useEncryption)
        {
            saveJson = EncryptDecrypt(saveJson);
        }

        string saveFilePath = SavePath + saveFileName + ".json";

        File.WriteAllText(saveFilePath, saveJson);
        Debug.Log("Save Success: " + saveFilePath);
    }

    public static SaveData Load(string saveFileName, bool useEncryption)
    {
        string saveFilePath = SavePath + saveFileName + ".json";

        if (!File.Exists(saveFilePath))
        {
            Debug.LogError("No such saveFile exists");
            return null;
        }

        string saveFile = File.ReadAllText(saveFilePath);
        if (useEncryption)
        {
            saveFile = EncryptDecrypt(saveFile);
        }
        SaveData saveData = JsonUtility.FromJson<SaveData>(saveFile);
        return saveData;
    }

    private static string EncryptDecrypt(string saveJson)
    {
        string modified = "";
        for(int i = 0; i < saveJson.Length; i++)
        {
            modified += (char)(saveJson[i] ^ encryptionCodeWord[i % encryptionCodeWord.Length]);
        }

        return modified;
    }
}

public class SaveController : MonoBehaviour
{
    [Header("Notice: If doesn't work, change encryption mode")]
    [SerializeField]
    private bool useEncryption = true;
    void Start()
    {
        if (!File.Exists(SaveSystem.SavePath + "playerinfo" + ".json"))
        {
            Save();
        }
        Load();
    }
    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            Save();   
        }
        if (Input.GetKeyDown("l"))
        {
            Load();
        }
    }

    void Save()
    {
        SaveData character = new SaveData(UserData.name, UserData.gold, UserData.tapgold, UserData.currentswordlevel, UserData.Gsuccesschancelevel);

        SaveSystem.Save(character, "playerinfo", useEncryption);
    }

    void Load()
    {
        SaveData loadData = SaveSystem.Load("playerinfo", useEncryption);
        if (loadData != null)
        {
            Debug.Log(string.Format("LoadData Result => name : {0}, gold : {1} ...etc", loadData.name, loadData.gold));
            UserData.name = loadData.name;
            UserData.gold = loadData.gold;
            UserData.tapgold = loadData.tapgold;
            UserData.currentswordlevel = loadData.currentswordlevel;
            UserData.Gsuccesschancelevel = loadData.Gsuccesschancelevel;
        }
    }
}
