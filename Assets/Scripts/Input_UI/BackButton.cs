﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private PlayerStateManager playerStateManager;
    private SZMemory szMemory;
    private SZController szController;

    private void Start()
    {
        playerStateManager = PlayerStateManager.Instance;
        szMemory = SZMemory.Instance;
        szController = SZController.Instance;

        GetComponent<Button>().onClick.AddListener(OnButtonClicked);
    }
    private void OnButtonClicked()
    {
        if(szMemory.GetCurrentStageZone().GetParent() == null)
        {
            playerStateManager.SwitchFromSZ_ToFP();
        }
        else
        {
            playerStateManager.SwitchFromSZ_ToSZ_UP();
        }

        gameObject.active = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        szController.Pause();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        szController.Unpause();
    }
}
