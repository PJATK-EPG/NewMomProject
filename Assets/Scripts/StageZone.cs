using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StageZone : MonoBehaviour
{
    //хранит всю информацию о
    //1)дети-родители
    //2)камера инфо

    [SerializeField] private GameObject cameraArm;
    [SerializeField] private GameObject cameraPoint;

    [Range(0.5f, 2)]
    [SerializeField] private float distance = 1f;

    [Range(0.5f, 2)]
    [SerializeField] private float minimalDistance= 0.5f;

    [Range(0.5f, 2)]
    [SerializeField] private float maxDistance = 2f;

    private CameraParams camParams;
    private void Start()
    {
        camParams = new CameraParams(cameraArm.transform.position, cameraArm.transform.eulerAngles, cameraPoint.transform.localPosition);
    }

    public CameraParams GetCamParams()
    {
        return camParams;
    }

    private void OnValidate()
    {
        cameraPoint.transform.localPosition = new Vector3(0, 0, -1*distance);
    }

    private void OnDrawGizmosSelected()
    {
        //Point sphere
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(cameraArm.transform.position, cameraPoint.transform.position);

        //Point sphere
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(cameraPoint.transform.position, 0.1f);
        Gizmos.DrawWireSphere(cameraPoint.transform.position, 0.11f);

        //Point minDistance
        Handles.color = Color.yellow;
        Handles.DrawWireDisc(cameraArm.transform.position, Vector3.up, minimalDistance);

        //Point minDistance
        Handles.color = Color.red;
        Handles.DrawWireDisc(cameraArm.transform.position, Vector3.up, maxDistance);

        if(maxDistance> minimalDistance 
            && maxDistance >= (-1)*cameraPoint.transform.localPosition.z 
            && minimalDistance <= (-1) * cameraPoint.transform.localPosition.z)
        {
            Handles.color = new Color(0.09f, 0.58f, 0, 0.1f);
        }
        else
        {
            Handles.color = new Color(1, 0, 0, 0.1f);
        }
        Handles.DrawSolidDisc(cameraArm.transform.position, Vector3.up, maxDistance);
    }
}
