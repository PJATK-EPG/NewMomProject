using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{
    [SerializeField] protected StateInputHandler inputHandler;
    protected bool isActive;

    private void Update()
    {
        if (isActive)
            inputHandler.HandleInput();
    }
    public abstract void Lock();
    public abstract void Unlock();

    public void Pause() => isActive = false;

    public void Unpause() => isActive = true;

}
