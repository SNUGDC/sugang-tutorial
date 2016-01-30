using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuManager : MonoBehaviour
{
	public void startNew()
    {
        SceneManager.LoadScene("stage0");
    }
    
    public void load()
    {
        
    }
    
    public void credits()
    {
        SceneManager.LoadScene("credit");
    }
}
