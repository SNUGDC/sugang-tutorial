using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class Dialogue
{
    public string name { get; private set; }
    public string text { get; private set; }
    public Dialogue(string name, string text)
    {
        this.name = name; this.text = text;
    }
}

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text talkText;

    public bool isTyping = false;
    public int nextDialogueIndex = 0;
    public bool spaceButtonEnabled = true;
    public bool xButtonEnabled = true;

    [HideInInspector]
    public List<Dialogue> dialogues;
    public TextAsset jsonFile;

    private JsonReader jsonReader;
    private JsonData dialogueData;
    
    void Start()
    {
        jsonReader = new JsonReader(jsonFile.text);
        loadData();
        startDialogue();
    }
    void Update()
    {
        if (Input.GetKeyDown("space") && !isTyping && spaceButtonEnabled)
        {
            gotoNextDialogue();
        }
        if (Input.GetKeyDown("x") && isTyping && xButtonEnabled)
        {
            isTyping = false;
        }
    }
    private void loadData()
    {
        //dialogueData = JsonMapper.ToObject(jsonReader);
        // Dictionary<string, List<Dialogue>> dialogueDict = jsonFileToDict(jsonReader);

        JsonData jsonData = JsonMapper.ToObject(jsonReader);
        Dictionary<string, List<Dialogue>> dialogueDict = ToDictionary(jsonData,
            dialogues => JsonMapper.ToObject<List<Dialogue>>(dialogues.ToJson()));

        foreach (var item in dialogueDict.Keys)
        {
            Debug.Log(item + " : " + dialogueDict[item][0]);
        }
        loadDialogue("dialogue-" + SceneLoader.stageNum);
    }
    
    private Dictionary<string, T> ToDictionary<T>(JsonData jsonData, Func<JsonData, T> transformer) {
        
        Dictionary<string, T> result = new Dictionary<string, T>();
        foreach(string key in jsonData.Keys) 
        {
            JsonData val = jsonData[key];
            T deserializedVal = transformer(val);
            result.Add(key, deserializedVal);
        }
        
        return result;
    }
    
    public void loadDialogue(string name)
    {
        dialogues = new List<Dialogue>();
        IEnumerable lines = dialogueData[name];
        foreach (var line in lines)
        {
            dialogues.Add(stringToDialogue(line.ToString()));
        }
    }
    public void startDialogue(int startIndex = 0)
    {
        nextDialogueIndex = startIndex;
        gameObject.SetActive(true);
        gotoNextDialogue();
    }
    private void stopDialogue()
    {
        gameObject.SetActive(false);
    }
    public void gotoNextDialogue()
    {
        if (nextDialogueIndex >= dialogues.Count)
        {
            stopDialogue();
            return;
        }
        Dialogue nextLine = dialogues[nextDialogueIndex];
        nameText.text = nextLine.name;
        isTyping = true;
        StartCoroutine(typingEffect(talkText, nextLine.text, 0.1f));
        nextDialogueIndex++;
    }
    private IEnumerator typingEffect(Text textComponent, string text, float interval)
    {
        string tempText = "";
        foreach (char c in text)
        {
            if (!isTyping) {
                textComponent.text = text;
                yield break;
            }
            tempText += c;
            textComponent.text = tempText;
            yield return new WaitForSeconds(interval);
        }
        isTyping = false;
        yield return new WaitForEndOfFrame();
    }
    public Dialogue stringToDialogue(string line)
    {
        string[] lineData = line.ToString().Split(':');
        return new Dialogue(lineData[0], lineData[1]);
    }
    // helper function for converting a jsonObject to a dictionary
    // public Dictionary<string, List<Dialogue>> jsonFileToDict(JsonReader reader)
    // {
    //     Dictionary<string, List<Dialogue>> dict = new Dictionary<string, List<Dialogue>>();
    //     string key = string.Empty;
    //     string val = string.Empty;
    //     while (reader.Read())
    //     {
    //         if(reader.Token == LitJson.JsonToken.ObjectEnd)
    //         {
    //             return dict;
    //         }
    //         else if(reader.Token == LitJson.JsonToken.ObjectStart)
    //         {
    //             dict.Add(key, jsonFileToDict(reader));
    //         }
    //         else if(reader.Token == LitJson.JsonToken.PropertyName)
    //         {
    //             key = reader.Value.ToString();
    //         }
    //         else
    //         {
    //             val = reader.Value.ToString();
    //         }
    //         if(key != string.Empty && val != string.Empty)
    //         {
    //             dict.Add(key, val);
    //             key = string.Empty;
    //             val = string.Empty;
    //         }
    //     }
    //     return dict;
    // }
}
