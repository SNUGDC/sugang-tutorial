using UnityEngine;
using System.Collections.Generic;

public class EnrolmentUI : MonoBehaviour {
    public SubjectRow subjectResultRowExample;
    public GameObject subjectRowParent;

    // example data.
    private List<Subject> subjects = new List<Subject>();
    
    public void Start() {
        addSubject(code: "001", name: "Let's make game.", department: "itct", maxEnrolment: 20);
        addSubject(code: "002", name: "Let's make game.", department: "itct", maxEnrolment: 20);
        addSubject(code: "003", name: "Let's make game.", department: "itct", maxEnrolment: 20);
        addSubject(code: "004", name: "Let's make game.", department: "itct", maxEnrolment: 20);
        addSubject(code: "005", name: "Let's make game.", department: "itct", maxEnrolment: 20);
        addSubject(code: "006", name: "Let's make game.", department: "itct", maxEnrolment: 20);
        addSubject(code: "007", name: "Let's make game.", department: "itct", maxEnrolment: 20);
        addSubject(code: "008", name: "Let's make game.", department: "itct", maxEnrolment: 20);
        addSubject(code: "009", name: "Let's make game.", department: "itct", maxEnrolment: 20);
        addSubject(code: "010", name: "Let's make game.", department: "itct", maxEnrolment: 20);
        
        foreach(var subject in subjects) {
            var row = Instantiate<SubjectRow>(subjectResultRowExample);
            row.transform.SetParent(subjectRowParent.transform);
            row.Setup(subject);
            row.transform.position = subjectResultRowExample.transform.position;
            row.transform.localScale = subjectResultRowExample.transform.localScale;
            row.gameObject.SetActive(true);
        }
    }

    public void addSubject(string code, string name, string department, int maxEnrolment) {
        var subject = new Subject();
        subject.code = code;
        subject.name = name;
        subject.department = department;
        
        subjects.Add(subject);
        EnrolmentSingleton.Instance.DB.Set(subject, maxEnrolment);
    }
}