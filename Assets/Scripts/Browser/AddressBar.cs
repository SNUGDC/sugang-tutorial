﻿using UnityEngine;
using UnityEngine.UI;

public class AddressBar : MonoBehaviour 
{
    public InputField inputField;
    
    
    void Update()
    {
        if (inputField.isFocused && Input.GetKeyDown(KeyCode.Return))
            SubmitAddress();
    }
	
    void SubmitAddress()
    {
        string address = inputField.text;
        
        if (string.IsNullOrEmpty(address) || address.Equals("http://"))
            return;
        
        string parsedString;
        
        if (address.Length < 8 || !address.Substring(0, 7).Equals("http://"))
            parsedString = "http://";
        else
            parsedString = "";
        
        parsedString += address.ToLower();
        
        if (!address[address.Length-1].Equals('/'))
            parsedString += "/";
            
        inputField.text = parsedString;
        MoveToSite(SiteInfo.Search(parsedString));
    }
    
    void MoveToSite(int siteIndex)
    {
        Debug.Log(siteIndex);
    }
}
