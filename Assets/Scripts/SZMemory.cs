using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SZMemory : MonoBehaviour
{
    public static SZMemory Instance { get; private set; }

    private Stack<StackInfo> stack;
    private StageZone aimStageZone;
    private StageZone currentStageZone;
    private StageZone previousStageZone;

    private void Awake()
    {
        Instance = this;
    }
    public void SetAimLocation(StageZone newStageZone)
    {
        aimStageZone = newStageZone;
    }
    public void SetCurrentLocation(StageZone newStageZone)
    {
        newStageZone.Disactivate();
        currentStageZone = newStageZone;
    }

    public StageZone GetCurrentStageZone()
    {
        return currentStageZone;
    }
}



public class StackInfo
{
    public StageZone stageZone;
    public CameraParams camParams;

    public StackInfo(StageZone stageZone, CameraParams camParams)
    {
        this.stageZone = stageZone;
        this.camParams = camParams;
    }
}