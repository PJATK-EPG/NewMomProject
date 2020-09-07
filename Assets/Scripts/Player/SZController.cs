﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SZController : MonoBehaviour
{

    //dobavit ograniczenie
    public static SZController Instance { get; private set; }

    [SerializeField] private Transform additionalCamera;
    [SerializeField] private Transform cameraArm;

    private Vector3 localRotation;
    private float cameraDistance = 50f;

    private float mouseSensitivity = 4f;
    private float scrollSensitvity = 2f;
    private float orbitDampening = 10f;
    private float scrollDampening = 6f;

    //private bool cameraEnable;
    private bool isMousePressed;

    private bool isActive;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (isActive)
        {
            HandleMouse();
            HandleScrollWheel();
        }
    }

    public void HandleMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMousePressed = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMousePressed = false;
        }
        if (isMousePressed)
        {
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                localRotation.x += Input.GetAxis("Mouse X") * mouseSensitivity;
                localRotation.y += Input.GetAxis("Mouse Y") * mouseSensitivity;

                if (localRotation.y < 0f)
                    localRotation.y = 0f;
                else if (localRotation.y > 90f)
                    localRotation.y = 90f;
            }

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
            cameraDistance = Mathf.Clamp(cameraDistance, 1.5f, 100f);
        }
        if (additionalCamera.localPosition.z != cameraDistance * -1f)
        {
            additionalCamera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(additionalCamera.localPosition.z, cameraDistance * -1f, Time.deltaTime * scrollDampening));
        }
    }


    //добавить на лок/анлок появление мыши, появление гуи, реакцию стейдж зон
    public void Lock() => isActive = false;
    public void Unlock() => isActive = true;

}