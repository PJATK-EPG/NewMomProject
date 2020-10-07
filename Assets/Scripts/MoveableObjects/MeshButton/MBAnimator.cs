using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBAnimator : MonoBehaviour
{
    [SerializeField] private Activator meshButtonActivator;
    [SerializeField] private Transform meshBody;
    [SerializeField] private Transform endPoint;
    [SerializeField] private float animationTime;

    [SerializeField] private SimpleWaiter waiter;

    private bool canMoveBack;
    private bool canMoveWithReturn;
    private bool isFirstStepMade;


    public void MoveBack()
    {
        if (meshButtonActivator.isActivated())
        {
            canMoveBack = true;
        }
    }
    public void MoveWithReturn()
    {
        if (meshButtonActivator.isActivated())
        {
            canMoveWithReturn = true;
            isFirstStepMade = true;
        }
    }

    void Update()
    {
        if (canMoveBack)
        {
            MakeMoveBack();
        }
        else if (canMoveWithReturn)
        {
            MakeMoveWithBack();
        }
    }

    private void MakeMoveBack()
    {
        if (Vector3.Distance(meshBody.localPosition, endPoint.localPosition) > 0.001f)
        {
            meshBody.localPosition = Vector3.MoveTowards(meshBody.localPosition, endPoint.localPosition, animationTime * Time.deltaTime);
        }
        else
        {
            canMoveBack = false;
            waiter.Finish();
        }
    }

    private void MakeMoveWithBack()
    {
        if (isFirstStepMade)
        {
            if (Vector3.Distance(meshBody.localPosition, endPoint.localPosition) > 0.001f)
            {
                meshBody.localPosition = Vector3.MoveTowards(meshBody.localPosition, endPoint.localPosition, animationTime * Time.deltaTime);
            }
            else
            {
                isFirstStepMade = false;
            }
        }
        else
        {
            if (Vector3.Distance(meshBody.localPosition, Vector3.zero) > 0.001f)
            {
                meshBody.localPosition = Vector3.MoveTowards(meshBody.localPosition, Vector3.zero, animationTime * Time.deltaTime);
            }
            else
            {
                canMoveWithReturn = false;
            }
        }
        
    }
}
