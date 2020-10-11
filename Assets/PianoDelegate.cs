using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoDelegate : WaiterDelegate
{
    public List<Activator> pianoKeys = new List<Activator>();
    public override void OnActivated()
    {
        foreach(Activator pianoKey in pianoKeys)
        {
            pianoKey.ActivateThisObj();
        }
    }

    public override void OnFinished()
    {
    }

    public override void OnMakedUsed()
    {
    }
}
