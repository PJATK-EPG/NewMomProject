using UnityEngine;
using UnityEngine.Playables;

public class StarBoxDelegate : WaiterDelegate
{
    [SerializeField] private PlayableDirector playableDirector;
    
    public override void OnActivated()
    {
        playableDirector.Play();
    }

    public override void OnFinished()
    {
    }

    public override void OnMakedUsed()
    {
    }
}
