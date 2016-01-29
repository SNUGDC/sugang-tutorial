using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public struct Dialogue {
    public string name {get; set;}
    public string text {get; set;}
    public Dialogue(string name, string text) {
        this.name = name; this.text = text;
    }
}

public class DialogueManager : MonoBehaviour {
    
    public Text nameText;
    public Text talkText;
    
    public bool dialoguePlaying = true;
    public int dialogueIndex = 0;
    
    [HideInInspector]
    public List<Dialogue> dialogues;
    public JsonData dialogueData;
    public TextAsset jsonFile;
    
    private JsonReader jsonReader;

    void Start()
    {
        jsonReader = new JsonReader(jsonFile.text);
        loadData();
        startDialogue();
    }
    void Update()
    {
        if(Input.GetKeyDown("space")) {
            gotoNextDialogue();
        }
    }
    public void loadData()
    {
        dialogueData = JsonMapper.ToObject(jsonReader);
        loadDialogue("dialogue-1");
    }
    public void loadDialogue(string name)
    {
        dialogues = new List<Dialogue>();
        IEnumerable lines = dialogueData[name];
        foreach(var line in lines) {
            string[] lineData = line.ToString().Split(':');
            dialogues.Add(new Dialogue(lineData[0], lineData[1]));
        }
        
        foreach(Dialogue dialogue in dialogues) {
            Debug.Log(dialogue.name + ", " + dialogue.text);
        }
    }
    public void startDialogue()
    {
        dialogueIndex = 0;
        gameObject.SetActive(true);
        gotoNextDialogue();
    }
    public void stopDialogue()
    {
        gameObject.SetActive(false);
    }
    public void gotoNextDialogue()
    {
        if (dialogueIndex >= dialogues.Count) {
            stopDialogue();
            return;
        }
        Dialogue nextLine = dialogues[dialogueIndex];
        nameText.text = nextLine.name;
        StartCoroutine(typingEffect(talkText, nextLine.text, 0.1f));
        dialogueIndex++;
    }
    public IEnumerator typingEffect(Text textComponent, string text, float interval)
    {
        string tempText = "";
        foreach(char c in text) {
            tempText += c;
            textComponent.text = tempText;
            yield return new WaitForSeconds(interval);
        }
    }
}
