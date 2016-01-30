using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BrowserControl : MonoBehaviour 
{
    public TabControl[] tabs;
    public GameObject newTab;
    List<TabControl> openedTabs;
    Queue<TabControl> closedTabs;
    int maxTabNumber = 3;
    
	void Start()
    {
       openedTabs = new List<TabControl>();
       closedTabs = new Queue<TabControl>();
       
	   foreach (TabControl tab in tabs)
       {
           tab.Initialize();
           tab.Activating += ActivateTab;
           tab.Closing += CloseTab;
           
           if (tab.gameObject.activeInHierarchy)
               openedTabs.Add(tab);
           else
               closedTabs.Enqueue(tab);
       }
       ReallocateOrder();
	}
	
	void ActivateTab(int order)
    {
        for (int i=0; i<openedTabs.Count; i++)
        {
            if (i == order)
                continue;
            openedTabs[i].InactivateThis();
            openedTabs[i].transform.SetSiblingIndex(2);
        }
        openedTabs[order].transform.SetAsLastSibling();
    }
    void CloseTab(int order)
    {
        TabControl target = openedTabs[order];
        openedTabs.RemoveAt(order);
        closedTabs.Enqueue(target);
        ReallocateOrder();
        if (openedTabs.Count == 0)
        {
            CloseWindow();
            return;
        }
        openedTabs[openedTabs.Count - 1].ActivateThis();
    }
    public void OpenNewTab()
    {
        if (closedTabs.Count == 0)
            return;
        TabControl target = closedTabs.Dequeue();
        target.gameObject.SetActive(true);
        openedTabs.Add(target);
        ReallocateOrder();
        target.OpenThis();
    }
    void ReallocateOrder()
    {
        for (int i=0; i<openedTabs.Count; i++)
        {
            openedTabs[i].order = i;
            openedTabs[i].barButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(-235f, 303.8f) + Vector2.right * 250 * i;
        }
        newTab.GetComponent<RectTransform>().anchoredPosition = new Vector2(-329, 307) + Vector2.right * 250 * openedTabs.Count;
    }
    public void CloseWindow()
    {
        gameObject.SetActive(false);
    }
}