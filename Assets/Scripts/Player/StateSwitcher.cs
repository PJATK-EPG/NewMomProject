using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSwitcher : MonoBehaviour
{
    public static StateSwitcher Instance { get; private set; }
    private FPSController fpsState;
    private SZController szState;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        fpsState = FPSController.Instance;
        szState = SZController.Instance;
    }

    public void SwitchToFP()
    {
        fpsState.Unlock();
    }

    public void SwitchToSZ()
    {
        szState.Unlock();
    }
}
