using UnityEngine;
using System;
using System.Collections;

public class Navism : MonoBehaviour {
    public NavismDateTimeText navismDateTimeText;
    public void Start()
    {
        var now = System.DateTime.Now;
        var before10Minuate = new DateTime(
            year: now.Year,
            month: now.Month,
            day: now.Day,
            hour: 7,
            minute: 59,
            second: 50);
            
        navismDateTimeText.Setup(before10Minuate, before10Minuate.AddSeconds(1));
    }
}
