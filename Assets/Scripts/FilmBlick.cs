using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FilmBlick : MonoBehaviour
{
    public static FilmBlick Instance { get; private set; }

    public PlayableDirector playableDirector;
    public GameObject blackScreen;

    [SerializeField] private MyAnimation ShowBlackAnim;
    [SerializeField] private MyAnimation FadeInAnim;

    private MyAnimator myAnimator;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        myAnimator = MyAnimator.Instance;
    }

    public void MakeBlick()
    {
        //MyAnimation[] sequence = { ShowBlackAnim, FadeInAnim };
        //myAnimator.ProcessSequence(sequence);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            //MakeBlick();
            playableDirector.Play();
            blackScreen.SetActive(false);
        }
    }
}
