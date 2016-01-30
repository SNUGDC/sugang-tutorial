using UnityEngine;
using System.Collections;

public class TutorialMain : MonoBehaviour {

    public DialogueManager dialogueManager;
    public BrowserControl browserControl;

	// Use this for initialization
	void Start () {
        dialogueManager = GameObject.FindObjectOfType<DialogueManager>(); 
	    StartCoroutine(Logic());
	}
    
    private IEnumerator Logic()
    {
        yield return WaitForDialogueEnd();

        yield return WaitForChromeOpen();

        yield return WaitForDialogueEnd("dialogue-openMemo");

        yield return CommonPopupOpener.OpenCoroutine(
            title: "Lecture",
            firstLine: "PL",
            secondLine: "Understanding of Game",
            yesButtonText: "Yes",
            onClickYes: () => {},
            noButtonText: "No",
            onClickNo: () => {});

        yield return null;
    }
    
    private IEnumerator WaitForDialogueEnd()
    {
        while (dialogueManager.isRunning())
        {
            yield return null;
        }
        Debug.Log("dialogue end.");
    }
    
    private IEnumerator WaitForDialogueEnd(string dialogueName)
    {
        dialogueManager.loadDialogue("dialogue-openMemo");
        dialogueManager.startDialogue();
        
        yield return WaitForDialogueEnd();
        Debug.Log("Dialogue open : " + dialogueName);
    }

    private IEnumerator WaitForChromeOpen()
    {
        while(!browserControl.gameObject.activeSelf)
        {
            yield return null;
        }
        Debug.Log("Chrome Opened.");
    }
}
