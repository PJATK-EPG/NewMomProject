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
    [SerializeField] private Transform moveableObject;
    [SerializeField] private Transform minPoint;
    [SerializeField] private Transform maxPoint;
    
    void Update()
    {
        CheckState();
    }
    public void CheckState()
    {
        if (Vector3.Distance(moveableObject.transform.position , minPoint.transform.position) < 0.1f)
        {
            Debug.Log("MIN POINT!");
        }
        else if (Vector3.Distance(moveableObject.transform.position , maxPoint.transform.position) < 0.1f)
        {
            Debug.Log("MAX POINT!");
        }
    }
}
