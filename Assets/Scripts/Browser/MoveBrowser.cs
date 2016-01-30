using UnityEngine;
using System.Collections;

public class MoveBrowser : MonoBehaviour 
{
    public RectTransform browser;
    bool mouseOver = false;
    float multiplier;
    float maxX = 650;
    float maxY = 420;
    
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            Debug.Log("mouseup");
            StopAllCoroutines();
        }   
    }
    
    public void OnMouseDown()
    {
        StopAllCoroutines();
        StartCoroutine(DragWindow());
    }
    
    IEnumerator DragWindow()
    {
        float multiplier = 1280f/Screen.width;
        Vector3 prevPos = Input.mousePosition;
        yield return null;
        
        while (true)
        {
            Debug.Log(multiplier);
            Vector2 deltaPos = (Input.mousePosition - prevPos) * multiplier;
            ClampAnchor(browser, deltaPos);
            prevPos = Input.mousePosition;
            yield return null;
        }
    }
    
    void ClampAnchor(RectTransform target, Vector2 delta)
    {
        Vector2 prevPos = target.anchoredPosition;
        Debug.Log(prevPos.y + delta.y);
        Debug.Log(prevPos.x + delta.x);
        float newX = prevPos.x + delta.x;
        float newY = prevPos.y + delta.y;
        newX = Mathf.Clamp(newX, -maxX, maxX);
        newY = Mathf.Clamp(newY, -maxY, maxY);
        target.anchoredPosition = new Vector2(newX, newY);
    }
}
