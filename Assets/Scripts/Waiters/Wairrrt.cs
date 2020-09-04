using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wairrrt : MonoBehaviour
{/*
    private WaitersState state;
    [SerializeField] private List<SimpleWaiter> inWaiters = new List<SimpleWaiter>();
    [HideInInspector] public WaiterDelegate waiterDelegate;

    private void Start()
    {
        state = inWaiters.Count == 0 ? WaitersState.activated : WaitersState.deactivated;

        waiterDelegate = GetComponent<WaiterDelegate>();
    }

    private void Update()
    {
        CheckInWaiters();

        CheckChangingCondition();
    }

    private void CheckInWaiters()
    {
        if (state == WaitersState.deactivated)
        {
            bool canBeActivated = true;
            foreach (SimpleWaiter inWaiter in inWaiters)
            {
                //canBeActivated &= inWaiter.state == WaitersState.finished;
            }
            if (canBeActivated)
            {
                Activate();
            }
        }
    }
    private void CheckChangingCondition()
    {

        if (state == WaitersState.activated)
        {
            Activate();
        }
        if (state == WaitersState.stopped)
        {
            Stop();
        }
        else if (state == WaitersState.finished)
        {
            Finish();
        }
    }

    public void Activate()
    {
        state = WaitersState.activated;
        waiterDelegate.OnActivated();
    }

    public void Stop()
    {
        state = WaitersState.stopped;
        waiterDelegate.OnActivated();
    }

    public void Finish()
    {
        state = WaitersState.finished;
        waiterDelegate.OnActivated();
    }
*/}
