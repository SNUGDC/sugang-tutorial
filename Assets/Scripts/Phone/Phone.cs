using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Phone : MonoBehaviour {
    public Text phoneTimeText;

    void Update()
    {
        var currentTime = StageSingleton.instance.stageTime.GetCurrentStageTime();
        phoneTimeText.text = currentTime.ToString("hh :mm ss");
    } 
}
