using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBDelegate : WaiterDelegate
{
    [SerializeField] private StageZone stageZone;
    [SerializeField] private MeshButton meshButton;
    public override void OnActivated(){}

    public override void OnFinished(){}

    public override void OnMakedUsed()
    {
        stageZone.Disactivate();
        meshButton.Disactivate();
    }
}
