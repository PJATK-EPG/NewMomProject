using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FaderStates
{
    FaderMin,
    FaderMax, 
    None
}

public class Fader : MonoBehaviour
{
    [SerializeField] private Transform button;
    
    void Update()
    {
        CheckState();
    }
    public void CheckState()
    {
        //if (Mathf.Abs(button.transform.position.y - faderInformer.realMaxValue) < 0.1f)
        //{

        //}
        //else if (Mathf.Abs(button.transform.position.y - faderInformer.realMinValue) < 0.1f)
        //{

        //}
    }
}
