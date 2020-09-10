using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StageZone : MonoBehaviour
{
    //хранит всю информацию о
    //1)дети-родители
    //2)камера инфо

    [SerializeField] private StageZone parent;
    [SerializeField] private List<StageZone> children;

    [HideInInspector] public StageZoneInformer szInformer { get; private set; }

    private SphereCollider collider;
    private MeshRenderer meshRenderer;
    private void Awake()
    {
        szInformer = GetComponent<StageZoneInformer>();
        collider = GetComponent<SphereCollider>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public CameraParams GetDefaultCamParams()
    {
        return szInformer.GetDefaultCamParams();
    }

    public StageZoneParams GetStageZoneParams()
    {
        return szInformer.GetStageZoneParams();
    }

    public void Activate()
    {
        collider.enabled = true;
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
