using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderWaiters : WaiterDelegate, ISelectable
{
    [SerializeField] private Material activatedMaterial;
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material finishedMaterial;

    private SimpleWaiter waiter;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        waiter = GetComponent<SimpleWaiter>();
        meshRenderer = GetComponent<MeshRenderer>();
    }
    
    public override void OnActivated() => meshRenderer.material = activatedMaterial;
    public override void OnFinished() => meshRenderer.material = finishedMaterial;

    public void OnSelected()
    {
        if(waiter.state == WaitersState.activated)
        {
            meshRenderer.material = selectedMaterial;
            if (Input.GetKey(KeyCode.Tab))
            {
                waiter.Finish();
            }
        }
    }

    public void OnDeselected()
    {
        if (waiter.state == WaitersState.activated)
        {
            meshRenderer.material = activatedMaterial;
        }
    }
}
