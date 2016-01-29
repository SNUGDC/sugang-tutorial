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
        dialogueData = JsonMapper.ToObject(jsonReader);
        loadDialogue("dialogue-" + SceneLoader.stageNum);
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
}
