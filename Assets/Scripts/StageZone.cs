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
    private StageZoneInformer szInformer;

    private void Start()
    {
        szInformer = GetComponent<StageZoneInformer>();
    }

    public CameraParams GetDefaultCamParams()
    {
        return szInformer.GetDefaultCamParams();
    }

    public StageZoneParams GetStageZoneParams()
    {
        return szInformer.GetStageZoneParams();
    }
}
