using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using MonsterLove.StateMachine;

public class SemesterMain11 : StateBehaviour
{
    public enum States
    {
        ApplyingClasses,
        SearchedByClassName,
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
        Initialize<States>();
        ChangeState(States.ApplyingClasses);
    }
    void Start()
    {
        
    }
    private void logic()
    {
        
    }
    private void ApplyingClasses_Start()
    {
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
        if (!dialogueManager.isRunning() && nextState != States.ApplyingClasses)
        {
            ChangeState(nextState);
        }
    }
    private void SearchedByClassName_Enter()
    {
        dialogueManager.loadDialogue("dialogue-2-1");
        dialogueManager.startDialogue();
    }
    private void SearchedByClassName_Update()
    {
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
        dialogueManager.loadDialogue("dialogue-2-2");
        dialogueManager.startDialogue();
    }
    private void SearchedByNumber_Update()
    {
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
            SceneManager.LoadScene("stage03");
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
            SceneManager.LoadScene("scene03");
        }
    }
}
