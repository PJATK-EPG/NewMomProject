using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FaderState
{
    FaderMin,
    FaderMax, 
    None
}

public class Fader : MonoBehaviour
{
    [SerializeField] private Transform moveableObject;
    [SerializeField] private Transform minPoint;
    [SerializeField] private Transform pivotPoint;
    [SerializeField] private Transform maxPoint;

    [SerializeField] private bool shouldEndInMaxPoint;
    [SerializeField] private bool shouldEndInMinPoint;
    private bool shouldEndAnimation; 

    private FaderState faderState;

    private SimpleWaiter simpleWaiter;
    private Activator activator;
    private void Start()
    {
        simpleWaiter = GetComponent<SimpleWaiter>();
        activator = GetComponent<Activator>();
    }

    void Update()
    {
        if (activator.isActivated()) 
        {
            CheckState();

            if (shouldEndInMaxPoint && faderState == FaderState.FaderMax)
            {
                simpleWaiter.Finish();
                activator.DisactivateThisObj();
            }

            if (shouldEndInMinPoint && faderState == FaderState.FaderMin)
            {
                shouldEndAnimation = true;
                simpleWaiter.Finish();
                activator.DisactivateThisObj();
            }
        }
        if (shouldEndAnimation) 
        {
            MakeEndAnimation();
        }
    }
    public void CheckState()
    {
        if (Vector3.Distance(moveableObject.transform.position , minPoint.transform.position) < 0.1f)
        {
            faderState = FaderState.FaderMin;
        }
        else if (Vector3.Distance(moveableObject.transform.position , maxPoint.transform.position) < 0.1f)
        {
            faderState = FaderState.FaderMax;
        }
        else
        {
            faderState = FaderState.None;
        }
    }

    public void MakeEndAnimation()
    {
        if (shouldEndInMaxPoint)
        {
            if(Vector3.Distance(pivotPoint.position, maxPoint.position)< 0.01f)
            {
                moveableObject.position = Vector3.MoveTowards(moveableObject.position, maxPoint.position, 2 * Time.deltaTime);
            }
            else
            {
                shouldEndAnimation = false;
            }
        }
        else
        {
            if (Vector3.Distance(pivotPoint.position, minPoint.position) < 0.01f)
            {
                moveableObject.position = Vector3.MoveTowards(moveableObject.position, minPoint.position, 2 * Time.deltaTime);
            }
            else
            {
                shouldEndAnimation = false;
            }
        }
    }

}
