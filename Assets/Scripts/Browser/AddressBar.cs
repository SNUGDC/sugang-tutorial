using UnityEngine;
using UnityEngine.UI;

public class AddressBar : MonoBehaviour 
{
    public InputField inputField;
    public GameObject[] sites;
    
    void Start()
    {
        InactiveAll();
    }
    
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
        InactiveAll();
        sites[siteIndex].SetActive(true);
    }
    
    void InactiveAll()
    {
        for (int i=0; i<sites.Length; i++)
        {
            if (sites[i] != null)
                sites[i].SetActive(false);    
        }
    }
}
