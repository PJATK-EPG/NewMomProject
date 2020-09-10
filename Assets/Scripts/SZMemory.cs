using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SZMemory : MonoBehaviour
{
    public static SZMemory Instance { get; private set; }

    private SZController szController;

    private Stack<StackInfo> stack;
    private StageZone aimStageZone;
    private StageZone currentStageZone;
    private StageZone previousStageZone;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        stack = new Stack<StackInfo>();
        szController = SZController.Instance; 
    }
    public void SetAimLocation(StageZone newStageZone)
    {
        aimStageZone = newStageZone;
    }
    public void SetCurrentLocation(StageZone newStageZone)
    {
        newStageZone.Disactivate();
        stack.Push(new StackInfo(currentStageZone, szController.GetCameraParams()));
        currentStageZone = newStageZone;
    }

    public StackInfo MakeStepUp()
    {
        //2 варианта
        StackInfo stackInfo;
        if(stack.Count == 0)
        {
            stackInfo = new StackInfo(currentStageZone.GetParent(), currentStageZone.GetParent().GetDefaultCamParams());
        }
        else
        {

        }
        return stackInfo;
    }

    public void SetFPLocation()
    {
        currentStageZone.Activate();
        previousStageZone = currentStageZone;
        currentStageZone = null;
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