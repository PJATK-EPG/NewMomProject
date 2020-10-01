using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilmBlick : MonoBehaviour
{
    public static FilmBlick Instance { get; private set; }

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
        myAnimator.MakeAnimation(ShowBlackAnim);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            MakeBlick();
        }
    }
}
