using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine.UI;

public class EnrolmentUI : MonoBehaviour
{
    public enum State
    {
        SearchWindow, InterestWindow
    }
    public State windowState;
    public void setStateToSearch() {
        windowState = State.SearchWindow;
        Setup(exampleSubjects);
    }
    public void setStateToInterest() {
        windowState = State.InterestWindow;
        Setup(EnrolmentSingleton.Instance.interestSubjects);
    }
    
    public SubjectRow subjectResultRowExample;
    public GameObject subjectRowParent;

    // example data.
    private List<Subject> subjects = new List<Subject>();
    private List<Subject> exampleSubjects;

    private Subject selectedSubject = null;

    public event Action<Subject> OnEnrollEvent = (s) => {};

    private void Start() {
        // exampleSubjects = new List<Subject> {
        //     newSubject(code: "001", name: "Programming Language", department: "itct"),
        //     newSubject(code: "002", name: "대학국어", department: "itct"),
        //     newSubject(code: "003", name: "대학영어", department: "itct"),
        //     newSubject(code: "004", name: "공학수학", department: "itct"),
        //     newSubject(code: "005", name: "프로그래밍 연습", department: "itct"),
        //     newSubject(code: "006", name: "물리", department: "itct"),
        //     newSubject(code: "007", name: "화학", department: "itct"),
        //     newSubject(code: "008", name: "Let's make game.", department: "itct"),
        //     newSubject(code: "009", name: "Let's make game.", department: "itct"),
        //     newSubject(code: "010", name: "Let's make game.", department: "itct")
        // };

        var subjects = SubjectDataParser.Parse();
        Setup(subjects);
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

        if (OnEnrollEvent != null)
        {
            OnEnrollEvent.Invoke(selectedSubject);
        }
        else
        {
            if (selectedSubject == null)
            {
                CommonPopupOpener.Open("ERROR",
                    firstLine: "과목이 선택되지 않았습니다.",
                    secondLine: "",
                    yesButtonText: "OK",
                    onClickYes: () => {},
                    noButtonText: "Cancel",
                    onClickNo: () => {});
            }
            else
            {
                CommonPopupOpener.Open("ERROR",
                    firstLine: "수강 신청 기간이 아닙니다.",
                    secondLine: "",
                    yesButtonText: "OK",
                    onClickYes: () => {},
                    noButtonText: "Cancel",
                    onClickNo: () => {});
            }
        }
    }
    public void OnEnrollInterest()
    {
        var interestSubjects = EnrolmentSingleton.Instance.interestSubjects;
        Debug.Log("Enrolled interest");
        
        if (selectedSubject == null)
        {
            CommonPopupOpener.Open("ERROR",
                firstLine: "과목이 선택되지 않았습니다.",
                secondLine: "",
                yesButtonText: "OK",
                onClickYes: () => {},
                noButtonText: "Cancel",
                onClickNo: () => {});
        }
        else if (interestSubjects.Contains(selectedSubject))
        {
            CommonPopupOpener.Open("ERROR",
                firstLine: "이미 관심강좌에",
                secondLine: "등록되어 있습니다.",
                yesButtonText: "OK",
                onClickYes: () => {},
                noButtonText: "Cancel",
                onClickNo: () => {});
        }
        else
        {
            CommonPopupOpener.OpenSimpleSuccessPopup("성공", ()=>{}, ()=>{});
            interestSubjects.Add(selectedSubject);
        }
    }

    public void Search(string code, string name)
    {
        IEnumerable<Subject> query = subjects;
        if (code != "") {
            query = query.Where(subject => subject.code.Contains(code));
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

        subjects = subjects.Take(100).ToList();
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