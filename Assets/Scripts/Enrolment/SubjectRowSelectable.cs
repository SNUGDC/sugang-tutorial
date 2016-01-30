using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class SubjectRowSelectable : MonoBehaviour, IDeselectHandler, ISelectHandler
{
    private SubjectRow subjectRow;
    private void Start()
    {
        subjectRow = transform.parent.GetComponent<SubjectRow>();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        EnrolmentSingleton.Instance.FindEnrolmentUI().OnDeselectSubject(subjectRow.code.text);
    }

    public void OnSelect(BaseEventData eventData)
    {
        EnrolmentSingleton.Instance.FindEnrolmentUI().OnSelectSubject(subjectRow.code.text);
    }
}
