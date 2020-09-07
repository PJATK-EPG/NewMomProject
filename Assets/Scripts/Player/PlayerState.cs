using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{
    [SerializeField]private StateInputHandler inputHandler;
    protected bool isActive;

    private void Update()
    {
        if (isActive)
            inputHandler.HandleInput();
    }
    public abstract void Lock();
    public abstract void Unlock();

}
