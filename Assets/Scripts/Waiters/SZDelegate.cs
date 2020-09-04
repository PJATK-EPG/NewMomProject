using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SZDelegate : WaiterDelegate, ISelectable
{
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material redMaterial;

    //[SerializeField] private StageZone parent;
    //[SerializeField] private List<StageZone> children;
    private bool shouldRender;
    [SerializeField] private MeshRenderer sphereMeshRenderer;

    private SimpleWaiter waiter;

    private void Start()
    {
        shouldRender = Options.Instance.shouldRenderStageZones;
        sphereMeshRenderer.enabled = false;
    }
    public override void OnActivated()
    {
        if (shouldRender)
            sphereMeshRenderer.enabled = true;
    }

    public override void OnFinished()
    {
        throw new System.NotImplementedException();
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
