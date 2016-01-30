using UnityEngine;
using System;
using System.Collections;

public class TutorialMain : MonoBehaviour {

    public DialogueManager dialogueManager;
    public BrowserControl browserControl;

	// Use this for initialization
	void Start () {
      //  dialogueManager = GameObject.FindObjectOfType<DialogueManager>(); 
	    StartCoroutine(Logic());
	}
    
    private IEnumerator Logic()
    {
        yield return CoroutineHelper.WaitForDialogueEnd(dialogueManager);

        yield return CoroutineHelper.WaitForChromeOpen(browserControl);

        yield return CoroutineHelper.WaitForDialogueEnd(dialogueManager, "dialogue-openMemo");

        CommonPopupOpener.Open(
            title: "Lecture",
            firstLine: "sugang.snu.ac.kr 접속하기",
            secondLine: "Programming 수업수강신청하기",
            yesButtonText: "",
            onClickYes: () => {},
            noButtonText: "",
            onClickNo: () => {});

        yield return CoroutineHelper.WaitForEnroll("001");

        yield return null;
    }
}
