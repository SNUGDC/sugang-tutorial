using UnityEngine;
using System;

public class StageSingleton : MonoBehaviour
{
    public static StageSingleton instance;

    public static void resetSingleton()
    {
        instance = new StageSingleton();
    }

    
    public StageTime stageTime;
    public void SetCurrentTime(DateTime dateTime)
    {
        stageTime = new StageTime(stageStartStageTime: dateTime);
    }
    
    public class StageTime
    {
        public DateTime stageStartSystemTime;
        public DateTime stageStartStageTime;
        public StageTime(DateTime stageStartStageTime)
        {
            this.stageStartStageTime = stageStartStageTime;
            this.stageStartSystemTime = System.DateTime.Now;
        }
        public DateTime GetCurrentStageTime()
        {
            var diff = System.DateTime.Now - stageStartSystemTime;
            return stageStartStageTime + diff;
        }
    }
}