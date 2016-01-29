using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static int stageNum = 1;
    
    void Start()
    {
        stageNum = Application.loadedLevel;
    }
    void Update()
    {
        if (Input.GetKeyDown("["))
        {
            stageNum--;
            SceneManager.LoadScene("stage" + stageNum.ToString());
        }
        if (Input.GetKeyDown("]"))
        {
            stageNum++;
            SceneManager.LoadScene("stage" + stageNum.ToString());
        }
    }
}
