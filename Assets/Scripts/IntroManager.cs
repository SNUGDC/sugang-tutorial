using UnityEngine;
using System.Collections;

public class IntroManager : MonoBehaviour
{
    public DialogueManager dialogueManager;
    private bool waitingForInput = false;
    
    void Start()
    {
        StartCoroutine(waitForInput());
    }
    void Update()
    {
        if (!waitingForInput && !dialogueManager.isRunning())
        {
            StartCoroutine(waitForInput());
            waitingForInput = true;
        }
        if (Input.GetKeyDown("f5") && waitingForInput)
        {
            dialogueManager.loadDialogue("dialogue-0-1");
            dialogueManager.spaceButtonEnabled = true;
            dialogueManager.xButtonEnabled = true;
            dialogueManager.startDialogue();
            waitingForInput = false;
        }
    }
    private IEnumerator waitForInput()
    {
        yield return new WaitForSeconds(5.0f);
        if (!waitingForInput) yield break;
        dialogueManager.loadDialogue("dialogue-0-2");
        dialogueManager.spaceButtonEnabled = false;
        dialogueManager.xButtonEnabled = false;
        dialogueManager.startDialogue();
        yield return new WaitForSeconds(5.0f);
        if (!waitingForInput) yield break;
        dialogueManager.gotoNextDialogue();
        yield return new WaitForSeconds(5.0f);
        if (!waitingForInput) yield break;
        dialogueManager.gotoNextDialogue();
        yield return new WaitForSeconds(5.0f);
        if (!waitingForInput) yield break;
        dialogueManager.loadDialogue("dialogue-0-3");
        dialogueManager.spaceButtonEnabled = true;
        dialogueManager.xButtonEnabled = true;
        dialogueManager.startDialogue();
    }
}
