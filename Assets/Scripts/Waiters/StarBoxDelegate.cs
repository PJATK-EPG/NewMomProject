using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBoxDelegate : WaiterDelegate
{
    private MyAnimator myAnimator;
    private MyAnimation openAnimation;
    private void Start()
    {
        myAnimator = MyAnimator.Instance;
        openAnimation = GetComponent<MyAnimation>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //myAnimator.MakeAnimation(openAnimation);
        }
    }
    public override void OnActivated()
    {
        myAnimator.ProcessAnimation(openAnimation);
    }

    public override void OnFinished()
    {
    }

    public override void OnMakedUsed()
    {
    }
}
