using UnityEngine;
using System;
using System.Collections;

static class CoroutineHelper
{
    public static IEnumerator WaitForDialogueEnd(DialogueManager dialogueManager)
    {
        while (dialogueManager.isRunning())
        {
            yield return null;
        }
        Debug.Log("Dialogue End.");
    }
    public static IEnumerator WaitForDialogueEnd(DialogueManager dialogueManager, string dialogueName)
    {
        dialogueManager.loadDialogue(dialogueName);
        dialogueManager.startDialogue();
        
        yield return WaitForDialogueEnd(dialogueManager);
        Debug.Log("Dialogue open : " + dialogueName);
    }
    public static IEnumerator WaitForChromeOpen(BrowserControl browserControl)
    {
        while(!browserControl.gameObject.activeSelf)
        {
            yield return null;
        }
        Debug.Log("Chrome Opened.");
    }
    public static IEnumerator WaitForEnroll(string subjectCode)
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
            if (selectedSubject == null || selectedSubject.code != subjectCode)
            {
                CommonPopupOpener.OpenSimpleErrorPopup("잘못된 과목입니다. 다시하세요.");
            }
        };

        Debug.Assert(enrolmentUI != null);
        enrolmentUI.OnEnrollEvent += onEnroll;
        
        while (selectedSubject == null || selectedSubject.code != subjectCode)
        {
            yield return null;
        }
        
        enrolmentUI.OnEnrollEvent -= onEnroll;

        yield return CommonPopupOpener.OpenSimpleSuccessPopupCoroutine("성공");
    }
    
}