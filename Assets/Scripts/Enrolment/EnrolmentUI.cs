using UnityEngine;
using System.Collections.Generic;

public class EnrolmentUI : MonoBehaviour {
    public SubjectRow subjectResultRowExample;
    public GameObject subjectRowParent;

    // example data.
    private List<Subject> subjects = new List<Subject>();
    
    private void Start() {
        List<Subject> exampleSubjects = new List<Subject> {
            newSubject(code: "001", name: "Let's make game.", department: "itct"),
            newSubject(code: "002", name: "Let's make game.", department: "itct"),
            newSubject(code: "003", name: "Let's make game.", department: "itct"),
            newSubject(code: "004", name: "Let's make game.", department: "itct"),
            newSubject(code: "005", name: "Let's make game.", department: "itct"),
            newSubject(code: "006", name: "Let's make game.", department: "itct"),
            newSubject(code: "007", name: "Let's make game.", department: "itct"),
            newSubject(code: "008", name: "Let's make game.", department: "itct"),
            newSubject(code: "009", name: "Let's make game.", department: "itct"),
            newSubject(code: "010", name: "Let's make game.", department: "itct")
        };

        Setup(exampleSubjects);
    }
    public void Setup(List<Subject> subjectsInput) {
        this.subjects = subjectsInput;
        foreach(var subject in subjectsInput) {
            EnrolmentSingleton.Instance.DB.Set(subject, maxEnrolment: 20);    
        }

        foreach(var subject in subjects) {
            var row = Instantiate<SubjectRow>(subjectResultRowExample);
            row.transform.SetParent(subjectRowParent.transform);
            row.Setup(subject);
            row.transform.position = subjectResultRowExample.transform.position;
            row.transform.localScale = subjectResultRowExample.transform.localScale;
            row.gameObject.SetActive(true);
        }
    }

    private Subject newSubject(string code, string name, string department) {
        var subject = new Subject();
        subject.code = code;
        subject.name = name;
        subject.department = department;
        
        return subject;
    }
}