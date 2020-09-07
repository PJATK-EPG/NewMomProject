using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public static PlayerStateManager Instance { get; private set; }

    private FPSController fpsState;
    private SZController szState;
    private StateSwitcher switcher;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        fpsState = FPSController.Instance;
        szState = SZController.Instance;
        switcher = StateSwitcher.Instance;
    }

    public void SwitchToFP()
    {
        szState.Lock();
    }

    public void SwitchToSZ()
    {
        fpsState.Lock();
    }
}
