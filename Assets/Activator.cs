using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    private bool active;
    public void ActivateThisObj()
    {
        active = true;
    }

    public void DisactivateThisObj()
    {
        active = false;
    }

    public bool isActivated()
    {
        return active;
    }
}
