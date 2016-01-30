using UnityEngine;
using UnityEngine.UI;

public class IntroTimer : MonoBehaviour
{
    public Text timerText;
    public float elapsedTime;
    public int hours = 6;
    public int minutes = 59;
    public int seconds = 58;
    public bool isRunning = false;
    
    void Update()
    {
        if (isRunning) elapsedTime += Time.deltaTime;
        if (elapsedTime > 1.0f)
        {
            seconds++;
            elapsedTime = 0.0f;
            if (seconds >= 60) {
                seconds -= 60; minutes++;
                if (minutes >= 60) {
                    minutes -= 60; hours++;
                }
            }
        }
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
}
