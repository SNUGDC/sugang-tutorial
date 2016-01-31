using UnityEngine;
using UnityEngine.UI;

public class AddressBar : MonoBehaviour
{
    public InputField inputField;
    public GameObject[] sites;
    public Text tabTitle;
    
    void Start()
    {
        InactiveAll();
    }
    
    bool isFocusedLastFrame = false;
    
    void Update()
    {
        if (inputField.isFocused)
            isFocusedLastFrame = true;
        if (isFocusedLastFrame && Input.GetKeyDown(KeyCode.Return))
            SubmitAddress();
        
        isFocusedLastFrame = inputField.isFocused;
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
    
    public void MoveToSite(int siteIndex)
    {
        InactiveAll();
        sites[siteIndex].SetActive(true);
        switch (siteIndex)
        {
            case 0:
                tabTitle.text = "페이지를 찾을 수 없음";
            break;
            case 1:
                tabTitle.text = "서울대학교 수강신청";
            break;
            case 2:
                tabTitle.text = "서울대학교 포털";
            break;
        }
    }
    
    void InactiveAll()
    {
        for (int i=0; i<sites.Length; i++)
        {
            if (sites[i] != null)
                sites[i].SetActive(false);    
        }
    }
    
    public void OnEnable()
    {
        inputField.text = "";
        tabTitle.text = "새 탭";
        InactiveAll();
    }
}
