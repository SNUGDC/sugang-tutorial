using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine.UI;

public class EnrolmentUI : MonoBehaviour {
    public SubjectRow subjectResultRowExample;
    public GameObject subjectRowParent;

    // example data.
    private List<Subject> subjects = new List<Subject>();

    private Subject selectedSubject = null;
    
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

    public void OnDeselectSubject(string code)
    {
        if (selectedSubject == null || selectedSubject.code != code)
        {
            Debug.LogError("Not selected object is delselected : " + code);
        }
        selectedSubject = null;
        Debug.Log("Subject deselected");
    }

    public void OnSelectSubject(string code)
    {
        selectedSubject = subjects.Where(subject => subject.code == code).First();
        Debug.Log("Select : " + selectedSubject.name); 
    }

    public void OnEnRoll()
    {
        Debug.Log("EnRolled");
    }

    public void Search(string code, string name)
    {
        IEnumerable<Subject> query = subjects;
        if (code != "") {
            query = query.Where(subject => subject.code == code);
        }
        if (name != "") {
            query = query.Where(subject => subject.name.Contains(name));
        }
        
        ShowSubjects(query.ToList());
    }

    public void Setup(List<Subject> subjectsInput) {
        this.subjects = subjectsInput;
        foreach(var subject in subjectsInput) {
            EnrolmentSingleton.Instance.DB.Set(subject, maxEnrolment: 20);    
        }

        ShowSubjects(subjects);
    }
    
    private void ShowSubjects(List<Subject> subjects)
    {
        foreach (Transform child in subjectRowParent.transform)
        {
            if (child.gameObject != subjectResultRowExample.gameObject)
            {
                Destroy(child.gameObject);
            }
        }

        foreach(var subject in subjects)
        {
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