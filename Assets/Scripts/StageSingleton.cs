using UnityEngine;

public class StageSingleton : MonoBehaviour
{
    public static StageSingleton instance;

    public void resetSingleton()
    {
        instance = null;
    }
}