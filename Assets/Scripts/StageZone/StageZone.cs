using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StageZone : MonoBehaviour
{
    [SerializeField] private StageZone parent;
    [SerializeField] private List<StageZone> children;

    [HideInInspector] public SZInformer szInformer { get; private set; }

    private SphereCollider collider;
    private MeshRenderer meshRenderer;
    private void Awake()
    {
        szInformer = GetComponent<SZInformer>();
        collider = GetComponent<SphereCollider>();
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void Start()
    {
        if (parent != null)
        {
            Disactivate();
        }
    }

    public CameraParams GetDefaultCamParams()
    {
        return szInformer.GetDefaultCamParams();
    }

    public StageZoneParams GetStageZoneParams()
    {
        return szInformer.GetStageZoneParams();
    }

    public void Enable()
    {
        collider.enabled = true;
        if(Options.Instance.shouldRenderStageZones)
            meshRenderer.enabled = true;
        foreach(StageZone child in children)
        {
            child.Disactivate();
        }
    }

    public void Disable()
    {
        collider.enabled = false;
        meshRenderer.enabled = false;
        foreach (StageZone child in children)
        {
            child.Activate();
        }
    }


    public void Activate()
    {
        collider.enabled = true;
        if (Options.Instance.shouldRenderStageZones)
            meshRenderer.enabled = true;
    }

    public void Disactivate()
    {
        collider.enabled = false;
        meshRenderer.enabled = false;
    }

    public bool isParentOf(StageZone stageZone)
    {
        return children.Contains(stageZone);
    }
    
    public StageZone GetParent()
    {
        return parent;
    }
}
