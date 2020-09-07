using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageZone : MonoBehaviour
{
    //хранит всю информацию о
    //1)дети-родители
    //2)камера инфо

    [SerializeField] private GameObject cameraArm;
    [SerializeField] private GameObject cameraPoint;
    private CameraParams camParams;
    private void Start()
    {
        camParams = new CameraParams(cameraArm.transform.position, cameraArm.transform.eulerAngles, cameraPoint.transform.localPosition);
    }

    public CameraParams GetCamParams()
    {
        return camParams;
    }
}
