using UnityEngine;
using UnityEngine.Playables;

public class StarBoxDelegate : WaiterDelegate
{
    [SerializeField] private PlayableDirector playableDirector;
    [SerializeField] private AudioClip drawerClick;

    private Activator activator;
    private AudioSource audioSource;

    private void Start()
    {
        activator = GetComponent<Activator>();
        audioSource = GetComponent<AudioSource>();
    }
    public override void OnActivated()
    {
        playableDirector.Play();
        activator.ActivateThisObj();
    }

    public override void OnFinished()
    {
        audioSource.PlayOneShot(drawerClick);
    }

    public override void OnMakedUsed()
    {
        activator.DisactivateThisObj();
    }
}
