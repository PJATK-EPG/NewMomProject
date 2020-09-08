using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BackButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private SZController szController;

    private void Start()
    {
        szController = SZController.Instance;
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
