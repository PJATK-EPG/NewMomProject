using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SimpleWaiter))]
public abstract class WaiterDelegate : MonoBehaviour
{
    public abstract void OnActivated();
    public abstract void OnFinished();
}
