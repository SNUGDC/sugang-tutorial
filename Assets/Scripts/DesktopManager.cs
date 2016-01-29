using UnityEngine;
using System.Collections.Generic;

public class DesktopManager : MonoBehaviour
{
    public Icon[] icons;
    
    void Start()
    {
        icons = GetComponentsInChildren<Icon>(gameObject);
    }
    public void deselectIcons()
    {
        foreach(var icon in icons)
        {
            icon.isSelected = false;
        }
    }
}