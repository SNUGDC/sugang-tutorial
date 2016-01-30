using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class EnrollButton : MonoBehaviour
{
    public void OnEnrollButtonClicked()
    {
        EnrolmentSingleton.Instance.FindEnrolmentUI().OnEnRoll();
    }
}
