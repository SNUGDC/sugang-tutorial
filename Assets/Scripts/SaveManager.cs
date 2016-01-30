using UnityEngine;
using System.Text;
using LitJson;

public class Savefile
{
    public int currentLevel;
    public int succeededUnits;
}

public class SaveManager : MonoBehaviour
{
    public TextAsset jsonFile;
    private JsonReader jsonReader;
    private JsonWriter jsonWriter;
    public Savefile currentSavefile;
    
    void Start()
    {
        jsonReader = new JsonReader(jsonFile.text);
        
        /*
        StringBuilder sb = new StringBuilder();
        jsonWriter = new JsonWriter(sb);
        
        jsonWriter.WriteObjectStart();
        */
    }
    public void save(Savefile savefile)
    {
        
    }
    public void load()
    {
        JsonData jsonObject = JsonMapper.ToObject(jsonReader);
        currentSavefile = new Savefile();
        currentSavefile.currentLevel = int.Parse((string)jsonObject["currentLevel"]);
        currentSavefile.succeededUnits = int.Parse((string)jsonObject["succeededUnits"]);
    }
}