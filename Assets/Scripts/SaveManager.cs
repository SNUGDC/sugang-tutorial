using UnityEngine;
using System.Collections.Generic;
using System.Text;
using LitJson;

public class Savefile
{
    public int currentLevel;
    public int succeededUnits;
    public List<Subject> succeededSubjects;
}

public class SaveManager : MonoBehaviour
{
    private JsonWriter jsonWriter;
    private StringBuilder jsonString;
    public Savefile currentSavefile;
    
    void Start()
    {
        jsonString = new StringBuilder();
        jsonWriter = new JsonWriter(jsonString);
    }
    public void save(Savefile savefile)
    {
        JsonMapper.ToJson(savefile, jsonWriter);
        PlayerPrefs.SetString("save", jsonString.ToString());
    }
    public void load()
    {
        if (PlayerPrefs.HasKey("save"))
            currentSavefile = JsonMapper.ToObject<Savefile>(PlayerPrefs.GetString("save"));
        else
            Debug.Log("Cannot find save file!");
    }
}