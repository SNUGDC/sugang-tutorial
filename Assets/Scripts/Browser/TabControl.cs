using UnityEngine;
using UnityEngine.UI;

public class TabControl : MonoBehaviour
{
    public int order;
    public delegate void CallBack(int order);
    public event CallBack Closing;
    public event CallBack Activating;
    public ColorBlock activeColor;
    public ColorBlock inactiveColor;
    public Button barButton;
    public Text tabBarText;

    public EnrolmentUI enrolmentUIPrefab;
    public GameObject enrolmentUIParent;
    public AddressBar addressBar;

    private void Awake()
    {
        var enrolmentUI = GameObject.Instantiate<EnrolmentUI>(enrolmentUIPrefab);
        enrolmentUI.transform.SetParent(enrolmentUIParent.transform);
        enrolmentUI.transform.localPosition = enrolmentUIPrefab.transform.localPosition;
        enrolmentUI.transform.localScale = enrolmentUIPrefab.transform.localScale;
        addressBar.sites[1] = enrolmentUI.gameObject;
    }

    public void OpenThis()
    {
        ActivateThis();
    }
    public void CloseThis()
    {
        Closing(order);
        gameObject.SetActive(false);
    }
    public void ActivateThis()
    {
        barButton.colors = activeColor;
        Activating(order);
    }
    public void InactivateThis()
    {
        barButton.colors = inactiveColor;
    }
    
    public void OpenAddress(string address)
    {
        
    }
}