using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Credit : MonoBehaviour {
    public float timeSecond = 10;
    public Scrollbar scrollBar;
	// Update is called once per frame

    public Image blackIn;
    public Image whiteOut;

	void Start () {
	   StartCoroutine(AutoScroll());
	}
    
    IEnumerator BlackIn()
    {
        whiteOut.enabled = false;
        for (float time = 0; time < 1; time += Time.deltaTime)
        {
            blackIn.color = new Color(blackIn.color.r, blackIn.color.b, blackIn.color.g, 1 - (time / 1));
            yield return null;
        }
        blackIn.enabled = false;
    }
    
    IEnumerator WhiteOut()
    {
        yield return new WaitForSeconds(8f);

        whiteOut.enabled = true;
        for (float time = 0; time < 3; time += Time.deltaTime)
        {
            whiteOut.color = new Color(whiteOut.color.r, whiteOut.color.b, whiteOut.color.g, (time / 3));
            yield return null;
        }
        
        
    }
    IEnumerator AutoScroll()
    {
        StartCoroutine(BlackIn());

        yield return new WaitForSeconds(0.5f);
        float currentTime = 0;
        
        while(currentTime < timeSecond)
        {
            currentTime += Time.deltaTime;
            scrollBar.value = 1 - (currentTime / timeSecond);
            yield return null;
        }
        
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("menu");
    }
}
