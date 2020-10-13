using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PianoDelegate : WaiterDelegate
{
    [SerializeField] private List<Activator> pianoKeys = new List<Activator>();
    [SerializeField] private PlayableDirector openStarBoxCutScene;
    public override void OnActivated()
    {
        foreach(Activator pianoKey in pianoKeys)
        {
            pianoKey.ActivateThisObj();
        }
    }

    public override void OnFinished()
    {
        openStarBoxCutScene.Play();
    }

    public override void OnMakedUsed()
    {
    }
}
