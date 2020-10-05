using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SZSelector : MonoBehaviour, ISelectable
{
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material selectedMaterial;

    private MeshRenderer meshRenderer;
    private StageZone stageZone;
    private PlayerStateManager playerStateManager;
    private SZMemory szMemory;

    private float clicked = 0;
    private float clicktime = 0;
    private float clickdelay = 0.5f;


    void Start()
    {
        stageZone = GetComponent<StageZone>();
        meshRenderer = GetComponent<MeshRenderer>();
        playerStateManager = PlayerStateManager.Instance;
        szMemory = SZMemory.Instance;
        if (!Options.Instance.shouldRenderStageZones)
            meshRenderer.enabled = false;
    }

    public void OnSelected()
    {
        if (Options.Instance.shouldRenderStageZones)
            meshRenderer.material = selectedMaterial;
        if (Input.GetMouseButtonDown(0))
        {
            if (playerStateManager.stateType == PlayerStateType.FirstPerson)
            {
                playerStateManager.SwitchFromFP_ToSZ(stageZone);
            }
            else if (DoubleClick() && playerStateManager.stateType == PlayerStateType.StageZone && isChild())
            {
                SelectAnimation();
            }
        }
    }

    public void OnDeselected()
    {
        if (Options.Instance.shouldRenderStageZones)
            meshRenderer.material = defaultMaterial;
    }

    private bool DoubleClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicked++;
            if (clicked == 1) clicktime = Time.time;
        }
        if (clicked > 1 && Time.time - clicktime < clickdelay)
        {
            clicked = 0;
            clicktime = 0;
            return true;
        }
        else if (clicked > 2 || Time.time - clicktime > 1) clicked = 0;
        return false;
    }

    private void SelectAnimation()
    {
        StageZone currentStageZone = szMemory.GetCurrentStageZone();
        if (currentStageZone == null)
        {
            playerStateManager.SwitchFromFP_ToSZ(stageZone);
        }
        else if (currentStageZone.isParentOf(stageZone))
        {
            playerStateManager.SwitchFromSZ_ToSZ_DOWN(stageZone);
        }
        else if (stageZone.isParentOf(currentStageZone))
        {

        }
    }

    private bool isChild()
    {
        return szMemory.GetCurrentStageZone().isParentOf(stageZone);
    }

}
