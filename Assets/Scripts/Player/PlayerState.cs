using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class PlayerState : MonoBehaviour
{
    [SerializeField] private IStateInputHandler inputHandler;
    private bool isActive;

    private void Update()
    {
        if (isActive)
            inputHandler.HandleInput();
    }
    public abstract void Lock();
    public abstract void Unlock();

}
