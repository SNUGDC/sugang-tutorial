using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Icon : MonoBehaviour
{
    private Image iconImage;
    public Text iconText;
    public GameObject iconSelectedEffect;
    
    public DesktopManager desktopManager;
    
    float doubleClickStart = 0;
    public bool isSelected = false;
    
    public UnityEvent buttonDoubleClickEvent;
    
    void Start()
    {
        iconImage = GetComponent<Image>();
    }
    void Update()
    {
        iconSelectedEffect.SetActive(isSelected);
    }
    
    public void OnMouseClickUp()
    {
        // Double click detection code
        if ((Time.time - doubleClickStart) < 0.3f)
        {
            this.OnDoubleClick();
            doubleClickStart = -1;
        }
        else
        {
            doubleClickStart = Time.time;
        }
        
        desktopManager.deselectIcons();
        isSelected = true;
    }
    
    void OnDoubleClick()
    {
        Debug.Log("Double clicked!");
        buttonDoubleClickEvent.Invoke();
    }
}