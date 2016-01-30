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
    
    public void OpenThis()
    {
        Initialize();
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
    
    public void Initialize()
    {
        
    }
}
