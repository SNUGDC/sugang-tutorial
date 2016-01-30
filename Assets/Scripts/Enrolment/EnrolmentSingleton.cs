using UnityEngine;
using System.Collections;

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
    public EnrolmentUI FindEnrolmentUI() {
        return GameObject.FindObjectOfType<EnrolmentUI>();
    }
}
