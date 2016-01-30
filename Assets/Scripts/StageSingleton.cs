using UnityEngine;
using System;

public class StageSingleton : MonoBehaviour
{
    public static StageSingleton instance;

    public static DateTime currentTime;
    public void resetSingleton()
    {
        instance = null;
    }
}