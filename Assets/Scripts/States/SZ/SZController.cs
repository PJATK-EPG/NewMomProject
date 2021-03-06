﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SZController : PlayerState
{   
    public static SZController Instance { get; private set; }

    public GameObject centerPoint;
    public GameObject vignette;
    public GameObject backButton;
    public GameObject diaryButton;
    public GameObject inventoryButton;

    [SerializeField] private SelectionManager selectionManager;
    [SerializeField] private SZMemory szMemory;
    private void Awake()
    {
        Instance = this;
    }

    public override void Lock()
    {
        this.isActive = false;
        backButton.SetActive(false) ;
    }

    public override void Unlock()
    {
        this.isActive = true;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        centerPoint.SetActive(false);
        vignette.SetActive(true);
        backButton.SetActive(true);
        diaryButton.SetActive(true);
        inventoryButton.SetActive(true);

        selectionManager.SetState(PlayerStateType.StageZone);

        inputHandler.GetComponent<SZInputHandler>().ResetParams();
        
    }

    public void PrepareForFirstReseting()
    {
        inputHandler.GetComponent<SZInputHandler>().isFirstReseting = true;
    }

    public void SetStageZoneParams(StageZoneParams szParams)
    {
        (inputHandler as SZInputHandler).SetStageZoneParams(szParams);
    }

    public CameraParams GetCameraParams()
    {
        return (inputHandler as SZInputHandler).GetCameraParams();
    }
}
