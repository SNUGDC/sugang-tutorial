using UnityEngine;
using System.Collections.Generic;

public class EnrolmentSingleton {
    private static EnrolmentSingleton instance;
    public static EnrolmentSingleton Instance {
        get {
            if (instance == null)
            {
                instance = new EnrolmentSingleton();
            }
            return instance;
        }
        set {
            instance = value;
        }
    }

    public EnrolmentDB DB = new EnrolmentDB();
    // 관심강의에 저장된 강좌들.
    public List<Subject> interestSubjects = new List<Subject>();
    
    public EnrolmentUI FindEnrolmentUI() {
        return GameObject.FindObjectOfType<EnrolmentUI>();
    }
}
