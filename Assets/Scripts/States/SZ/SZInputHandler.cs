﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SZController))]
public class SZInputHandler :  StateInputHandler
{
    [SerializeField] private Transform additionalCamera;
    [SerializeField] private Transform cameraArm;
    [SerializeField] private SelectionManager selectionManager;

    private StageZoneParams szParams;

    private Vector3 localRotation;
    private float cameraDistance;

    private float mouseSensitivity = 4f;
    private float scrollSensitvity = 2f;
    private float orbitDampening = 5f;
    private float scrollDampening = 6f;

    private Vector3 previousPosition;
    private Vector3 currentPosition;

    private bool isMousePressed;
    public bool isFirstReseting;
    public override void HandleInput()
    {
        HandleMouse();
        HandleScrollWheel();
    }

    public void HandleMouse()
    {
        if (Input.GetMouseButtonDown(0) && selectionManager.selectedObj == null)
        {
            isMousePressed = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMousePressed = false;
        }
        if (isMousePressed)
        {
            float localRotationX = localRotation.x + Input.GetAxis("Mouse X") * mouseSensitivity;
            float localRotationY = localRotation.y + Input.GetAxis("Mouse Y") * mouseSensitivity;

            localRotation.x = MyMathfClamp.Clamp(localRotationX, szParams.xBorder);
            localRotation.y = MyMathfClamp.Clamp(localRotationY, szParams.yBorder);
    
            Quaternion QT = Quaternion.Euler(localRotation.y, localRotation.x, 0);
            cameraArm.rotation = Quaternion.Lerp(cameraArm.rotation, QT, Time.deltaTime * orbitDampening);
        }
    }

    public void HandleScrollWheel()
    {   
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            float ScrollAmount = Input.GetAxis("Mouse ScrollWheel") * scrollSensitvity;
            ScrollAmount *= (cameraDistance * 0.3f);
            cameraDistance += ScrollAmount * -1f;
            cameraDistance = Mathf.Clamp(cameraDistance, szParams.zBorder[0], szParams.zBorder[1]);
        }
        if (additionalCamera.localPosition.z != cameraDistance * -1f)
        {
            additionalCamera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(additionalCamera.localPosition.z, cameraDistance * -1f, Time.deltaTime * scrollDampening));
        }
    }
    
    public void ResetParams()
    {
        isMousePressed = false;
        if (isFirstReseting)
        {
            localRotation = new Vector3( cameraArm.eulerAngles.y,0, 0);
            isFirstReseting = false;
        }
        else
        {
            localRotation = new Vector3(cameraArm.eulerAngles.y, cameraArm.eulerAngles.x, 0);
        }
        
        cameraDistance = additionalCamera.localPosition.z * -1;
        Debug.Log("Reseted");
    }

    public void SetStageZoneParams(StageZoneParams szParams)
    {
        this.szParams = szParams;
    }

    public CameraParams GetCameraParams()
    {
        return new CameraParams(cameraArm.position, cameraArm.eulerAngles, additionalCamera.localPosition);
    }
}
