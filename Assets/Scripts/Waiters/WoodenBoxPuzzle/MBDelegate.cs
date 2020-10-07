using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBDelegate : WaiterDelegate
{
    [SerializeField] private Activator meshButtonActivator;
    //[SerializeField] private List<Activator> activableObjects = new List<Activator>();
    public override void OnActivated()
    {
        meshButtonActivator.ActivateThisObj();
    }

    public override void OnFinished()
    {
    }

    public override void OnMakedUsed()
    {
        meshButtonActivator.DisactivateThisObj();
    }
}
