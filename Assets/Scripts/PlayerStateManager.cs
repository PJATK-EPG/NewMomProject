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
    public PlayerStateType stateType { get; private set; }

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
            stateType = PlayerStateType.FirstPerson;
            fpsState.Unlock();
        }
        else
        {
            stateType = PlayerStateType.StageZone;
            szState.Unlock();
        }
    }

    public void SwitchFromSZ_ToFP()
    {
        stateType = PlayerStateType.FirstPerson;

        szState.Lock();

        szMemory.SetFPLocation();

        switcher.MakeSwitchingAnimation(SwitchAnimType.SZ_TO_FP, switcher.GetFPCamParams());
    }

    public void SwitchFromFP_ToSZ(StageZone aimStageZone)
    {
        stateType = PlayerStateType.StageZone;
        fpsState.Lock();

        szMemory.SetStartLocation(aimStageZone);
        szState.SetStageZoneParams(aimStageZone.GetStageZoneParams());

        switcher.MakeSwitchingAnimation(SwitchAnimType.FP_TO_SZ, aimStageZone.GetDefaultCamParams());
    }

    public void SwitchFromSZ_ToSZ_DOWN(StageZone aimStageZone)
    {
        szState.Lock();

        szMemory.SetCurrentLocation(aimStageZone);
        szState.SetStageZoneParams(aimStageZone.GetStageZoneParams());

        switcher.MakeSwitchingAnimation(SwitchAnimType.SZ_TO_SZ_DOWN, aimStageZone.GetDefaultCamParams());
    }
    public void SwitchFromSZ_ToSZ_UP()
    {
        szState.Lock();

        StackInfo szParams = szMemory.MakeStepUp();
        szState.SetStageZoneParams(szParams.stageZone.GetStageZoneParams());

        switcher.MakeSwitchingAnimation(SwitchAnimType.SZ_TO_SZ_UP, szParams.camParams);
    }
}