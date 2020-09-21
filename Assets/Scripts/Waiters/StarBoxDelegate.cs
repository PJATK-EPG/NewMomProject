using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBoxDelegate : WaiterDelegate
{
    public override void OnActivated()
    {
        Debug.Log("WORKS!!!!");
    }

    public override void OnFinished()
    {
    }

    public override void OnMakedUsed()
    {
    }
}
