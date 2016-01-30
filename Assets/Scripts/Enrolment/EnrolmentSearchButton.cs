using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnrolmentSearchButton : MonoBehaviour {
	public InputField CodeQuery;
    public InputField NameQuery;

    private void Awake()
    {
        CodeQuery.text = "";
        NameQuery.text = "";
    }

    public void OnButtonClicked()
    {
        var enrolmentUI = EnrolmentSingleton.Instance.FindEnrolmentUI();
        enrolmentUI.Search(CodeQuery.text, NameQuery.text);
    }
}
