using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SZController : PlayerState
{
    //dobavit ograniczenie
    public static SZController Instance { get; private set; }

    public GameObject centerPoint;
    public GameObject vignette;
    public GameObject backButton;

    public GameObject selectionManager;
    private void Awake()
    {
        Instance = this;
    }

    //добавить на лок/анлок появление мыши, появление гуи, реакцию стейдж зон
    //ПРЯТАТЬ ПЕРСОНАЖА!!!

    public override void Lock()
    {
        this.isActive = false;
    }

    public override void Unlock()
    {
        this.isActive = true;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

       

        centerPoint.SetActive(false);
        vignette.SetActive(true);
        backButton.SetActive(true);

        selectionManager.SetActive(false);

        this.inputHandler.GetComponent<SZInputHandler>().ResetCameraDistance();
    }

    public void SetStageZoneParams(StageZoneParams szParams)
    {
        (inputHandler as SZInputHandler).SetStageZoneParams(szParams);
    }
}
