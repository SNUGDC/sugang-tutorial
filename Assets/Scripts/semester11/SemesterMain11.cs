using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using MonsterLove.StateMachine;

public class SemesterMain11 : StateBehaviour
{
    public enum States
    {
        ApplyingClasses,
        SearchedByClassName,
        WaitingSearch,
        SearchedByNumber,
        SavedClassesFirst,
        AfterSearchedByClassName,
        AfterSearchedByNumber       
    }
    
    public DialogueManager dialogueManager;
    public BrowserControl browser;
    
    //[HideInInspector]
    public States nextState = States.ApplyingClasses;
    public bool savedClasses = false;
    
    public List<Subject> requiredSubjectList = new List<Subject> {
    };
    
    void Awake()
    {
        StageSingleton.resetSingleton();
        StageSingleton.instance.SetCurrentTime(new DateTime(
            year: 2009,
            month: 1,
            day: 29,
            hour: 6,
            minute: 59,
            second: 50
        ));
        Initialize<States>();
        ChangeState(States.ApplyingClasses);
        Debug.Log("AwakeCalled");
    }
    private void ApplyingClasses_Enter()
    {
        Debug.Log("ApplyingClasses_Start called");
        CommonPopupOpener.Open(
            title: "Lecture",
            firstLine: "sugang.snu.ac.kr 접속하기",
            secondLine: "수강편람에 있는 데로 신청하기",
            yesButtonText: "",
            onClickYes: () => {},
            noButtonText: "",
            onClickNo: () => {});
    }
    private void ApplyingClasses_Update()
    {
        if (EnrolmentSingleton.Instance.FindEnrolmentUI() != null)
        {
            ChangeState(States.WaitingSearch);
        }
        if (!dialogueManager.isRunning() && nextState != States.ApplyingClasses)
        {
            ChangeState(nextState);
        }
    }
    private void WaitingSearch_Enter()
    {
        var enrolmentUI = EnrolmentSingleton.Instance.FindEnrolmentUI();
        enrolmentUI.BlockSearchByCode = () => ChangeState(States.SearchedByNumber);
        enrolmentUI.BlockSearchByName = () => ChangeState(States.SearchedByClassName);
    }
    private void SearchedByClassName_Enter()
    {
        var enrolUI = EnrolmentSingleton.Instance.FindEnrolmentUI();
        enrolUI.OnEnrollInterestCallback = () => savedClasses = true;

        // browser.gameObject.SetActive(false);
        dialogueManager.loadDialogue("dialogue-2-1");
        dialogueManager.startDialogue();
    }
    private void SearchedByClassName_Update()
    {
        // if (!dialogueManager.isRunning() && !browser.gameObject.activeSelf)
        // {
        //     browser.gameObject.SetActive(true);
        // }
        if (!dialogueManager.isRunning() && savedClasses)
        {
            ChangeState(States.AfterSearchedByClassName);
        }
    }
    private void AfterSearchedByClassName_Enter()
    {
        dialogueManager.loadDialogue("dialogue-2-1-1");
        dialogueManager.startDialogue();
    }
    private void AfterSearchedByClassName_Update()
    {
        if (!dialogueManager.isRunning())
        {
            SceneManager.LoadScene("stage03");
        }
    }
    private void SearchedByNumber_Enter()
    {
        var enrolUI = EnrolmentSingleton.Instance.FindEnrolmentUI();
        enrolUI.OnEnrollInterestCallback = () => savedClasses = true;

        // browser.gameObject.SetActive(false);
        dialogueManager.loadDialogue("dialogue-2-2");
        dialogueManager.startDialogue();
    }
    private void SearchedByNumber_Update()
    {
        // if (!dialogueManager.isRunning() && !browser.gameObject.activeSelf)
        // {
        //     browser.gameObject.SetActive(true);
        // }
        if (!dialogueManager.isRunning() && savedClasses)
        {
            ChangeState(States.AfterSearchedByNumber);
        }
    }
    private void AfterSearchedByNumber_Enter()
    {
        dialogueManager.loadDialogue("dialogue-2-2-1");
        dialogueManager.startDialogue();
    }
    private void AfterSearchedByNumber_Update()
    {
        if (!dialogueManager.isRunning())
        {
            // SceneManager.LoadScene("stage03");
            SceneManager.LoadScene("credit");
        }
    }
    private void SavedClassesFirst_Enter()
    {
         dialogueManager.loadDialogue("dialogue-2-3");
         dialogueManager.startDialogue();
    }
    private void SavedClassesFirst_Update()
    {
        if (!dialogueManager.isRunning())
        {
            // SceneManager.LoadScene("scene03");
            SceneManager.LoadScene("credit");
        }
    }
}
