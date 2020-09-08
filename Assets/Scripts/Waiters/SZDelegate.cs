using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SZDelegate : WaiterDelegate, ISelectable
{
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material redMaterial;
    private bool shouldRender;
    private MeshRenderer sphereMeshRenderer;

    private PlayerStateManager stateManager;
    private SimpleWaiter waiter;
    private StageZone stageZone;

    private void Start()
    {
        shouldRender = Options.Instance.shouldRenderStageZones;
        sphereMeshRenderer = GetComponent<MeshRenderer>();
        sphereMeshRenderer.enabled = false;

        stateManager = PlayerStateManager.Instance;
        waiter = GetComponent<SimpleWaiter>();
        stageZone = GetComponent<StageZone>();
    }
    public override void OnActivated()
    {
        if (shouldRender)
            sphereMeshRenderer.enabled = true;
    }

    public override void OnFinished()
    {
        //выключить коллайдер
        sphereMeshRenderer.enabled = false;
    }

    public void OnSelected()
    {
        if (waiter.state == WaitersState.activated)
        {
            sphereMeshRenderer.material = selectedMaterial;
            if (Input.GetKey(KeyCode.Mouse0))
            {
                sphereMeshRenderer.material = redMaterial;
                stateManager.SwitchFromFP_ToSZ(stageZone);
            }
        }
    }

    public void OnDeselected()
    {
        sphereMeshRenderer.material = defaultMaterial;
    }
}
