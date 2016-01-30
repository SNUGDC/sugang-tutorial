using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class IntroTransitionManager : MonoBehaviour
{
    public GameObject gameLogo;
    public GameObject snugdcLogo;
    
    void Start()
    {
        StartCoroutine(startScene());
    }
    
    private IEnumerator startScene()
    {
        gameLogo.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        gameLogo.SetActive(false);
        snugdcLogo.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        snugdcLogo.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("stage1");
    }
}
