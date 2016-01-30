using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static string stageName;
    public static int stageNum = 1;
    
    void Start()
    {
        stageName = Application.loadedLevelName;
        stageNum = int.Parse(stageName[stageName.Length-1].ToString());
        Debug.Log("stageName: " + stageName);
        Debug.Log("stageNum: " + stageNum.ToString());
    }
    void Update()
    {
        if (Input.GetKeyDown("["))
        {
            stageNum--;
            stageName = "stage" + stageNum.ToString();
            SceneManager.LoadScene(stageName);
        }
        if (Input.GetKeyDown("]"))
        {
            stageNum++;
            stageName = "stage" + stageNum.ToString();
            SceneManager.LoadScene(stageName);
        }
    }
}
