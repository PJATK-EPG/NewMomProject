using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBAnimator : MonoBehaviour
{
    [SerializeField] private Transform meshBody;
    [SerializeField] private Transform endPoint;

    [SerializeField] private float animationTime;

    private bool canMoveBack;

    public void MoveBack() => canMoveBack = true;

    void Update()
    {
        if (canMoveBack)
        {
            if(Vector3.Distance(meshBody.localPosition, endPoint.localPosition) > 0.01f)
            {
                Debug.Log("22" + Vector3.MoveTowards(meshBody.localPosition, endPoint.localPosition, animationTime * Time.deltaTime));

                meshBody.localPosition = Vector3.MoveTowards(meshBody.localPosition, endPoint.localPosition, animationTime * Time.deltaTime);
            }
            else
            {
                canMoveBack = false;
            }
        }
    }
}
