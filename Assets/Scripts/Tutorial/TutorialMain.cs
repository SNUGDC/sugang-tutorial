using UnityEngine;
using System;
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

        CommonPopupOpener.Open(
            title: "Lecture",
            firstLine: "PL",
            secondLine: "Understanding of Game",
            yesButtonText: "Yes",
            onClickYes: () => {},
            noButtonText: "No",
            onClickNo: () => {});

        yield return WaitForEnRoll();

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

    private IEnumerator WaitForEnRoll()
    {
        var enrolmentUI = EnrolmentSingleton.Instance.FindEnrolmentUI();
        while (enrolmentUI == null)
        {
            enrolmentUI = EnrolmentSingleton.Instance.FindEnrolmentUI();
            yield return null;   
        }
        
        Subject selectedSubject = null;
        Action<Subject> onEnroll = (selectedInput) => {
            selectedSubject = selectedInput;
            if (selectedSubject == null || selectedSubject.code != "001")
            {
                CommonPopupOpener.OpenSimpleErrorPopup("잘못된 과목입니다. 다시하세요.");
            }
        };

        Debug.Assert(enrolmentUI != null);
        enrolmentUI.OnEnrollEvent += onEnroll;
        
        while (selectedSubject == null || selectedSubject.code != "001")
        {
            yield return null;
        }
        
        enrolmentUI.OnEnrollEvent -= onEnroll;

        yield return CommonPopupOpener.OpenSimpleSuccessPopupCoroutine("성공");
    }
}
