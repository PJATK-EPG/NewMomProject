using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public static Options Instance { get; private set; }
    public bool shouldRenderStageZones;
    public bool isFP_isFirst;
    private void Awake()
    {
        Instance = this;
    }
}
