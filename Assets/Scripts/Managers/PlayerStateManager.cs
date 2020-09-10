using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStateType
{
    FirstPerson,
    StageZone
}
public class PlayerStateManager : MonoBehaviour
{
    public static PlayerStateManager Instance { get; private set; }
    private FPController fpsState;
    private SZController szState;
    private StateSwitcher switcher;
    private SZMemory szMemory;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        fpsState = FPController.Instance;
        szState = SZController.Instance;
        switcher = StateSwitcher.Instance;
        szMemory = SZMemory.Instance;

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
        szMemory.SetFPLocation();
        switcher.SwitchFromSZ_ToFP();
    }

    public void SwitchFromFP_ToSZ(StageZone aimStageZone)
    {
        fpsState.Lock();
        szMemory.SetCurrentLocation(aimStageZone);
        switcher.SwitchFromFP_ToSZ(aimStageZone);
    }

    public void SwitchFromSZ_ToSZ_DOWN(StageZone aimStageZone)
    {
        szState.Lock();
        szMemory.SetCurrentLocation(aimStageZone);
        switcher.SwitchFromSZ_ToSZ_DOWN(aimStageZone);

        
    }
    public void SwitchFromSZ_ToSZ_UP()
    {
        szState.Lock();
        switcher.SwitchFromSZ_ToSZ_UP();
    }
}