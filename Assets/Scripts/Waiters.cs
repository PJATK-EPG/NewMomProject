using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WaitersState
{
    deactivated,
    activated,
    stopped,
    finished
}
public class Waiters : MonoBehaviour
{
    private WaitersState state;
    [SerializeField] private List<Waiters> inWaiters = new List<Waiters>();
    [SerializeField] private List<Waiters> outWaiters = new List<Waiters>();
    
    private void Start()
    {
        if (inWaiters.Count == 0)
        {
            state = WaitersState.activated;
        }
        else
        {
            state = WaitersState.deactivated;
        }
    }

    private void Update()
    {
        CheckInWaiters();
        CheckChangingCondition();
    }

    private void CheckInWaiters()
    {
        if(state == WaitersState.deactivated)
        {
            bool canBeActivated = true;
            foreach(Waiters inWaiter in inWaiters)
            {
                canBeActivated &= inWaiter.state == WaitersState.finished;
            }
            if (canBeActivated)
            {
                
            }
        }
    }
    private void CheckChangingCondition()
    {
        throw new NotImplementedException();
    }

    public abstract void Activate()
    {
        //nie rabotaet w dwie storony
    }
}
