using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private ISelectable selectedObj;

    private PlayerStateType type;

    private void Start()
    {
        if (Options.Instance.isFP_isFirst)
        {
            type = PlayerStateType.FirstPerson;
        }
    }
    void Update()
    {
        if (selectedObj != null)
        {
            selectedObj.OnDeselected();
        }
        selectedObj = null;

        MakeRaycast();

        if (selectedObj != null)
        {
            selectedObj.OnSelected();
        }
    }

    public void MakeRaycast()
    {
        if (type == PlayerStateType.FirstPerson)
        {
            var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.transform.CompareTag("Selectable"))
                {
                    selectedObj = hit.transform.GetComponent<ISelectable>();
                }
            }
        }
        else if(type == PlayerStateType.StageZone)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.transform.CompareTag("Selectable"))
                {
                    selectedObj = hit.transform.GetComponent<ISelectable>();
                }
            }
        }
    }

    public void SetState(PlayerStateType type)
    {
        this.type = type;
    }
}
