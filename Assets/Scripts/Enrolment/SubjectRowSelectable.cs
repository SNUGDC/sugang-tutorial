using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class SubjectRowSelectable : MonoBehaviour
{
    private SubjectRow subjectRow;
    private void Start()
    {
        subjectRow = transform.parent.GetComponent<SubjectRow>();
    }

    public bool ToggleValue {
        set {
            if (value)
            {
                OnSelect();
            }
            else
            {
                OnDeselect();
            }
        }
    }

    public void OnDeselect()
    {
        EnrolmentSingleton.Instance.FindEnrolmentUI().OnDeselectSubject(subjectRow.code.text);
    }

    public void OnSelect()
    {
        EnrolmentSingleton.Instance.FindEnrolmentUI().OnSelectSubject(subjectRow.code.text);
    }
}
