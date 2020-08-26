using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WaitersState
{
    deactivated,
    activated,
    finished
}
public class SimpleWaiter : MonoBehaviour
{
    [SerializeField] private List<SimpleWaiter> inWaiters = new List<SimpleWaiter>();
    [HideInInspector] public WaiterDelegate waiterDelegate;
    [HideInInspector] public WaitersState state;

    private void Start()
    {
        state = inWaiters.Count == 0 ? WaitersState.activated : WaitersState.deactivated;
        
        waiterDelegate = GetComponent<WaiterDelegate>();
    }

    private void Update()
    {
        CheckInWaiters();
    }

    private void CheckInWaiters()
    {
        if(state == WaitersState.deactivated)
        {
            bool canBeActivated = true;
            foreach(SimpleWaiter inWaiter in inWaiters)
            {
                canBeActivated &= inWaiter.state == WaitersState.finished;
            }
            if (canBeActivated)
            {
                Activate();
            }
        }
    }
    
    public  void Activate()
    {
        state = WaitersState.activated;
        waiterDelegate.OnActivated();
    }

    public void Finish()
    {
        state = WaitersState.finished;
        waiterDelegate.OnFinished();
    }
}
