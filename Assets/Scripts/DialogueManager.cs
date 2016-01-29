﻿using UnityEngine;
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
    private Dictionary<string, List<Dialogue>> dialogueDict;
    
    void Start()
    {
        jsonReader = new JsonReader(jsonFile.text);
        dialogueDict = new Dictionary<string, List<Dialogue>>();
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
        Dictionary<string, List<string>> dialogueDictTemp = JsonMapper.ToObject<Dictionary<string, List<string>>>(jsonReader);
        // convert Dictionary<string, List<string>> to Dictionary<string, List<Dialogue>>
        foreach(string key in dialogueDictTemp.Keys)
        {
            var dialogueStringList = dialogueDictTemp[key];
            var dialogueList = new List<Dialogue>();
            foreach(string dialogueString in dialogueStringList)
            {
                dialogueList.Add(stringToDialogue(dialogueString));
            }
            dialogueDict.Add(key, dialogueList);
        }
        loadDialogue("dialogue-" + SceneLoader.stageNum);
    }
    public void loadDialogue(string name)
    {
        dialogues = dialogueDict[name];
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
}
