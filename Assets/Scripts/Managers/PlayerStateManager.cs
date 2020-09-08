using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public static PlayerStateManager Instance { get; private set; }

    private FPController fpsState;
    private SZController szState;
    private StateSwitcher switcher;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        fpsState = FPController.Instance;
        szState = SZController.Instance;
        switcher = StateSwitcher.Instance;
        if (Options.Instance.isFP_isFirst)
        {
            fpsState.Unlock();
        }
        else
        {
            szState.Unlock();
        }
    }

    public void SwitchFromSZ_ToFP()
    {
        szState.Lock();
        switcher.SwitchFromSZ_ToFP();
    }

    public void SwitchFromFP_ToSZ(StageZone stageZone)
    {
        fpsState.Lock();
        switcher.SwitchFromFP_ToSZ(stageZone);
    }
}
