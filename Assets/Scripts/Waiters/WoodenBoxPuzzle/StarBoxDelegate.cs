using UnityEngine;
using UnityEngine.Playables;

public class StarBoxDelegate : WaiterDelegate
{
    [SerializeField] private PlayableDirector playableDirector;

    private Activator activator;
    private void Start()
    {
        activator = GetComponent<Activator>();
    }
    public override void OnActivated()
    {
        playableDirector.Play();
        activator.ActivateThisObj();
    }

    public override void OnFinished()
    {
        Debug.Log("Finished!!!");
    }

    public override void OnMakedUsed()
    {
        activator.DisactivateThisObj();
    }
}
