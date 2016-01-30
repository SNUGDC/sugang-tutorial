using UnityEngine;
using System.Collections.Generic;
using System.Text;
using LitJson;

public class Savefile
{
    public int currentLevel;
    public int succeededUnits;
    public List<Subject> succeededSubjects;
    public List<Subject> requisiteSubjects;
    public string major;
    public string secondaryMajor;
    public Savefile()
    {
        succeededSubjects = new List<Subject>();
        requisiteSubjects = new List<Subject>();
    }
}

public static class SaveManager
{
    private static JsonWriter jsonWriter;
    private static StringBuilder jsonString;
    public static Savefile currentSavefile;
    
    public static void Initialize()
    {
        jsonString = new StringBuilder();
        jsonWriter = new JsonWriter(jsonString);
    }
    public static void NewData()
    {
        currentSavefile = new Savefile();
    }
    public static void Save(Savefile savefile)
    {
        JsonMapper.ToJson(savefile, jsonWriter);
        PlayerPrefs.SetString("save", jsonString.ToString());
    }
    public static void SaveCurrent()
    {
        Save(currentSavefile);
    }
    
    public static void Load()
    {
        if (PlayerPrefs.HasKey("save"))
            currentSavefile = JsonMapper.ToObject<Savefile>(PlayerPrefs.GetString("save"));
        else
            Debug.Log("Cannot find save file!");
    }
}