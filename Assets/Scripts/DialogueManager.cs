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

    [HideInInspector]
    public List<Dialogue> dialogues;
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
        if (Input.GetKeyDown("space") && !isTyping)
        {
            gotoNextDialogue();
        }
        if (Input.GetKeyDown("x") && isTyping)
        {
            isTyping = false;
        }
    }
    private void loadData()
    {
        var dialogueData = JsonMapper.ToObject(jsonReader);
        loadDialogue("dialogue-1", dialogueData);
    }
    private void loadDialogue(string name, JsonData dialogueData)
    {
        dialogues = new List<Dialogue>();
        IEnumerable lines = dialogueData[name];
        foreach (var line in lines)
        {
            string[] lineData = line.ToString().Split(':');
            dialogues.Add(new Dialogue(lineData[0], lineData[1]));
        }

        foreach (Dialogue dialogue in dialogues)
        {
            Debug.Log(dialogue.name + ", " + dialogue.text);
        }
    }
    private void startDialogue(int startIndex = 0)
    {
        nextDialogueIndex = startIndex;
        gameObject.SetActive(true);
        gotoNextDialogue();
    }
    private void stopDialogue()
    {
        gameObject.SetActive(false);
    }
    private void gotoNextDialogue()
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
}
