using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SubjectRow : MonoBehaviour {
    public Text code;
    public Text category;
    public Text department;
    public Text name;
    public Text maxEnrolment;
    public Text currentEnrolment;
    
    private void Awake() {
        // code.text = category.text = department.text
        //  = name.text = maxEnrolment.text
        //  = currentEnrolment.text = "EMPTY";
    }
    
    public void Setup(Subject subject) {
        code.text = subject.code;
        category.text = subject.category.ToString();
        department.text = subject.department;
        name.text = subject.name;
        var enrolmentData = EnrolmentSingleton.Instance.DB.GetEnrolment(subject);
        maxEnrolment.text = enrolmentData.MaxEnrolment.ToString();
        currentEnrolment.text = enrolmentData.CurrentEnrolment.ToString();
    }
}
