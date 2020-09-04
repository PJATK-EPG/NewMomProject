using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private ISelectable selectedObj;

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
        var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.transform.CompareTag("Selectable"))
            {
                selectedObj = hit.transform.GetComponent<ISelectable>();
            }
        }
    }
}
