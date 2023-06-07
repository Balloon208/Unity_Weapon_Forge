using System;
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
    public int swordstone;
    public int dungeonstone;
    public int currentswordlevel;
    public int[] Gupgrade = new int[5];
    public int successball;
    public int removeball;

    private SaveData(SavaDataBuilder savaDataBuilder)
    {
        name = savaDataBuilder.name;
        currentswordlevel = savaDataBuilder.currentswordlevel;
        gold = savaDataBuilder.gold;
        tapgold = savaDataBuilder.tapgold;
        swordstone = savaDataBuilder.swordstone;
        dungeonstone = savaDataBuilder.dungeonstone;

        for (int i = 0; i < 5; i++)
        {
            Gupgrade[i] = savaDataBuilder.gupgrade[i];
        }
        successball = savaDataBuilder.successball;
        removeball = savaDataBuilder.removeball;
    }

    public class SavaDataBuilder
    {
        public string name;
        public int gold;
        public int tapgold;
        public int swordstone;
        public int dungeonstone;
        public int currentswordlevel;
        public int[] gupgrade = new int[5];
        public int successball;
        public int removeball;
        public SavaDataBuilder Name(string name)
        {
            this.name = name;
            return this;
        }
        public SavaDataBuilder Currentswordlevel(int currentswordlevel)
        {
            this.currentswordlevel = currentswordlevel;
            return this;
        }
        public SavaDataBuilder Gold(int gold)
        {
            this.gold = gold;
            return this;
        }
        public SavaDataBuilder Swordstone(int swordstone)
        {
            this.swordstone = swordstone;
            return this;
        }
        public SavaDataBuilder Dungeonstone(int dungeonstone)
        {
            this.dungeonstone = dungeonstone;
            return this;
        }
        public SavaDataBuilder TapGold(int tapgold)
        {
            this.tapgold = tapgold;
            return this;
        }
        public SavaDataBuilder Gupgrade(int[] gupgrade)
        {
            for (int i = 0; i < 5; i++)
            {
                this.gupgrade[i] = gupgrade[i];
            }
            return this;
        }
        public SavaDataBuilder Successball(int successball)
        {
            this.successball = successball;
            return this;
        }
        public SavaDataBuilder Removeball(int removeball)
        {
            this.removeball = removeball;
            return this;
        }
        public SaveData Build()
        {
            return new SaveData(this);
        }

    }
}

public static class SaveSystem // save location -> C:\Users\{username}\AppData\LocalLow\{addition_location}
{
    public static string SavePath => Application.persistentDataPath + "/saves/";
    private static string encryptionCodeWord = "SoloGame";
    // private static bool useEncryption = true;


    public static void Save(SaveData saveData, string saveFileName ,bool useEncryption)
    {
        if (!Directory.Exists(SavePath)) // 존재하지 않으면 새로 만들어준다.
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
        SaveData character = new SaveData.SavaDataBuilder()
            .Name(UserData.name)
            .Currentswordlevel(UserData.currentswordlevel)
            .Gold(UserData.gold)
            .Swordstone(UserData.swordstone)
            .Dungeonstone(UserData.dungeonstone)
            .TapGold(UserData.tapgold)
            .Gupgrade(UserData.Gupgrade)
            .Successball(UserData.successball)
            .Removeball(UserData.removeball)
            .Build();

        SaveSystem.Save(character, "playerinfo", useEncryption);
    }

    void Load()
    {
        SaveData loadData = SaveSystem.Load("playerinfo", useEncryption);
        if (loadData != null)
        {
            Debug.Log(string.Format("LoadData Result => name : {0}, gold : {1} ...etc", loadData.name, loadData.gold));
            UserData.name = loadData.name;
            UserData.currentswordlevel = loadData.currentswordlevel;

            UserData.gold = loadData.gold;
            UserData.swordstone = loadData.swordstone;
            UserData.dungeonstone = loadData.dungeonstone;
            UserData.tapgold = loadData.tapgold;
            UserData.Gupgrade = loadData.Gupgrade;
            UserData.successball = loadData.successball;
            UserData.removeball = loadData.removeball;
        }
    }
}
