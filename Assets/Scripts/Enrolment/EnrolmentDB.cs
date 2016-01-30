using UnityEngine;
using System.Collections.Generic;

public class EnrolmentDB {
    Dictionary<string, EnrolmentData> datas = new Dictionary<string, EnrolmentData>();
    public EnrolmentData GetEnrolment(Subject subject) {
        return datas[subject.code];
    }
    
    public void Set(Subject subject, int maxEnrolment) {
        if (datas.ContainsKey(subject.code))
        {
            return;
        }
        datas.Add(subject.code, new EnrolmentData(maxEnrolment));
    }
}

public class EnrolmentData {
    public int MaxEnrolment { get; private set; }
    public int CurrentEnrolment { get; private set; }
    
    public EnrolmentData(int maxEnrolment) {
        MaxEnrolment = maxEnrolment;
        CurrentEnrolment = 0;
    }
}
