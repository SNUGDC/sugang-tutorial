using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using MonsterLove.StateMachine;

public class IntroManager : StateBehaviour
{
    public enum States
    {
        Init,
        BrowserOpen,
        WaitForInput,
        ActivateTrap,
        GiveUp
    }

    private AudioSource audioSource;
    public DialogueManager dialogueManager;
    public GameObject sugangTerrorImage;
    public BrowserControl browser;
    public IntroTimer introTimer;
    
    private bool waitingForInput = false;

    void Awake()
    {
        Initialize<States>();
        ChangeState(States.Init);
    }
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Init_Enter()
    {
        Debug.Log("Entered Init!");
    }
    private void Init_Update()
    {
        if (!dialogueManager.isRunning() && browser.gameObject.activeSelf)
        {
            ChangeState(States.BrowserOpen);
        }
    }
    private void BrowserOpen_Enter()
    {
        Debug.Log("Entered BrowserOpen!");
        browser.OpenSugang();
        dialogueManager.loadDialogue("dialogue-0-1");
        dialogueManager.startDialogue();
    }
    private void BrowserOpen_Update()
    {
        if (!dialogueManager.isRunning())
        {
            ChangeState(States.WaitForInput);
        }
    }
    
    private IEnumerator WaitForInput_Enter()
    {
        Debug.Log("Entered WaitForInput!");
        dialogueManager.loadDialogue("dialogue-0-2");
        dialogueManager.spaceButtonEnabled = false;
        dialogueManager.xButtonEnabled = false;
        dialogueManager.startDialogue();
        yield return new WaitForSeconds(10.0f);
        dialogueManager.gotoNextDialogue();
        yield return new WaitForSeconds(7.5f);
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
        if (Input.GetKeyDown("f5"))
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
        audioSource.Play();
        introTimer.isRunning = true;
        yield return new WaitForSeconds(3.0f);
        introTimer.isRunning = false;
        dialogueManager.loadDialogue("dialogue-0-3");
        dialogueManager.spaceButtonEnabled = true;
        dialogueManager.xButtonEnabled = true;
        dialogueManager.startDialogue();
    }
    private void ActivateTrap_Update()
    {
        if (!dialogueManager.isRunning())
        {
            SceneManager.LoadScene("intro_transition");
        }
    }
    private IEnumerator GiveUp_Enter()
    {
        Debug.Log("Entered GiveUp!");
        yield return new WaitForSeconds(2.0f);
        dialogueManager.loadDialogue("dialogue-0-4");
        dialogueManager.spaceButtonEnabled = true;
        dialogueManager.xButtonEnabled = true;
        dialogueManager.startDialogue();
    }
    private void GiveUp_Update()
    {
        if (!dialogueManager.isRunning())
        {
            SceneManager.LoadScene("intro_transition");
        }
    }
}
