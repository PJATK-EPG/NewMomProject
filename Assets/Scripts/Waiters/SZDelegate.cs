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

    private SimpleWaiter waiter;

    private void Start()
    {
        shouldRender = Options.Instance.shouldRenderStageZones;
        sphereMeshRenderer = GetComponent<MeshRenderer>();
        waiter = GetComponent<SimpleWaiter>();
        sphereMeshRenderer.enabled = false;
    }
    public override void OnActivated()
    {
        if (shouldRender)
            sphereMeshRenderer.enabled = true;
    }

    public override void OnFinished()
    {

    }

    public void OnSelected()
    {
        if (waiter.state == WaitersState.activated)
        {
            sphereMeshRenderer.material = selectedMaterial;
            if (Input.GetKey(KeyCode.Mouse0))
            {
                sphereMeshRenderer.material = redMaterial;
            }
        }
    }

    public void OnDeselected()
    {
        sphereMeshRenderer.material = defaultMaterial;
    }
}
