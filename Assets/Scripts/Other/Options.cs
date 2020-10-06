using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public static Options Instance { get; private set; }
    public bool isFP_isFirst;
    public bool shouldRenderStageZones;
    public bool shouldRenderSelectedObj;
    public bool shouldUseDefPoints;
    //should use default point
    private void Awake()
    {
        Instance = this;
    }
}
