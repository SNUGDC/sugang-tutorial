using UnityEngine;
using System.Collections;
using MonsterLove.StateMachine;

public class IntroManager : StateBehaviour
{
    public enum States
    {
        Init,
        WaitForInput,
        ActivateTrap,
        GiveUp
    }

    public DialogueManager dialogueManager;
    public GameObject sugangTerrorImage;
    public IntroTimer introTimer;
    
    private bool waitingForInput = false;

    void Awake()
    {
        Initialize<States>();
        ChangeState(States.Init);
    }
    private void Init_Enter()
    {
        Debug.Log("Entered Init!");
    }
    private void Init_Update()
    {
        if (!dialogueManager.isRunning())
        {
            ChangeState(States.WaitForInput);
        }
    }
    private IEnumerator WaitForInput_Enter()
    {
        Debug.Log("Entered WaitForInput!");
        yield return new WaitForSeconds(5.0f);
        dialogueManager.loadDialogue("dialogue-0-2");
        dialogueManager.spaceButtonEnabled = false;
        dialogueManager.xButtonEnabled = false;
        dialogueManager.startDialogue();
        yield return new WaitForSeconds(5.0f);
        dialogueManager.gotoNextDialogue();
        yield return new WaitForSeconds(5.0f);
        dialogueManager.gotoNextDialogue();
        yield return new WaitForSeconds(5.0f);
        dialogueManager.stopDialogue();
    }
    private void WaitForInput_FixedUpdate()
    {
        if (!dialogueManager.isRunning())
        {
            ChangeState(States.GiveUp);
        }
        if (Input.GetKeyDown("f5") || Input.GetKeyDown("r"))
        {
            Debug.Log("f5 pressed!");
            dialogueManager.stopDialogue();
            ChangeState(States.ActivateTrap, StateTransition.Overwrite);
        }
    }
    private IEnumerator ActivateTrap_Enter()
    {
        Debug.Log("Entered ActivateTrap!");
        sugangTerrorImage.SetActive(true);
        introTimer.isRunning = true;
        yield return new WaitForSeconds(3.0f);
        introTimer.isRunning = false;
        dialogueManager.loadDialogue("dialogue-0-1");
        dialogueManager.spaceButtonEnabled = true;
        dialogueManager.xButtonEnabled = true;
        dialogueManager.startDialogue();
    }
    private IEnumerator GiveUp_Enter()
    {
        Debug.Log("Entered GiveUp!");
        yield return new WaitForSeconds(2.0f);
        dialogueManager.loadDialogue("dialogue-0-3");
        dialogueManager.spaceButtonEnabled = true;
        dialogueManager.xButtonEnabled = true;
        dialogueManager.startDialogue();
    }
}
