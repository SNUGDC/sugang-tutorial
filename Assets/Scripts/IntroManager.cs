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
            ChangeState(States.ActivateTrap, StateTransition.Overwrite);
        }
    }
    private void ActivateTrap_Enter()
    {
        Debug.Log("Entered ActivateTrap!");
        dialogueManager.loadDialogue("dialogue-0-1");
        dialogueManager.spaceButtonEnabled = true;
        dialogueManager.xButtonEnabled = true;
        dialogueManager.startDialogue();
    }
    private void GiveUp_Enter()
    {
        Debug.Log("Entered GiveUp!");
        dialogueManager.loadDialogue("dialogue-0-3");
        dialogueManager.spaceButtonEnabled = true;
        dialogueManager.xButtonEnabled = true;
        dialogueManager.startDialogue();
    }
}
