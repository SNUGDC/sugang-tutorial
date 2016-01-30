using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class NavismDateTimeText : MonoBehaviour {
    public Text dateTimeText;
    public DateTime dateTime = System.DateTime.Now;
    public AudioSource audioSource;
    public DateTime soundStartTime;

	void Update () {
	   var dateTimeString = dateTime.ToString("yyyy년 MM월 dd일 HH시 mm분 ss초");
       dateTimeText.text = dateTimeString;

       var previousTime = dateTime;
       dateTime = dateTime.AddSeconds(Time.deltaTime);

       if (previousTime <= soundStartTime && soundStartTime < dateTime)
       {
           audioSource.gameObject.SetActive(true);
       }
	}

    public void Setup(DateTime currentTime, DateTime soundStartTime)
    {
        dateTime = currentTime;
        this.soundStartTime = soundStartTime;
    }
}
