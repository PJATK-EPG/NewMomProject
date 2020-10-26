using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakebleItem : MonoBehaviour, ISelectable
{
    [SerializeField] private ItemObject itemObject;
    [Space(10)]
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material selectedMaterial;

    private Inventory inventory;
    private PlayerStateManager playerStateManager;
    private MeshRenderer meshRenderer;

    private float clicked = 0;
    private float clicktime = 0;
    private float clickdelay = 0.5f;

    private bool canFade;
    private float animationSpeed = 2f;
    private void Start()
    {
        inventory = Inventory.Instance;
        playerStateManager = PlayerStateManager.Instance;
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (canFade)
        {
            MakeFadeAnimation();
        }
    }
    public void OnSelected()
    {
        if (Options.Instance.shouldRenderSelectedObj)
        {
            meshRenderer.material = selectedMaterial;
        }
        if (DoubleClick() && playerStateManager.stateType == PlayerStateType.StageZone)
        {
            inventory.AddObjectToInventory(itemObject);
            canFade = true;
        }
    }

    public void OnDeselected()
    {
        if (Options.Instance.shouldRenderSelectedObj)
        {
            meshRenderer.material = defaultMaterial;
        }
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

    private void MakeFadeAnimation()
    {
        if(meshRenderer.material.color.a > 0)
        {
            Color prevColor = meshRenderer.material.color;
            meshRenderer.material.color = new Color(prevColor.r, prevColor.g, prevColor.b, prevColor.a - animationSpeed * Time.deltaTime);
        }
        else
        {
            canFade = false;
            meshRenderer.enabled = false;
        }
    }

}
