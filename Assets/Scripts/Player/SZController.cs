using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SZController : PlayerState
{
    //dobavit ograniczenie
    public static SZController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    //добавить на лок/анлок появление мыши, появление гуи, реакцию стейдж зон
    //ПРЯТАТЬ ПЕРСОНАЖА!!!
    public override void Lock()
    {
        this.isActive = false;
    }

    public override void Unlock()
    {
        this.isActive = true;
    }
}
