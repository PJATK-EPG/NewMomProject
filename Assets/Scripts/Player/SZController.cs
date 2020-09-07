using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SZController : MonoBehaviour
{
    public static SZController Instance { get; private set; }

    private bool isActive;

    private void Awake()
    {
        Instance = this;
    }


    //добавить на лок/анлок появление мыши, появление гуи, реакцию стейдж зон
    public void Lock() => isActive = false;
    public void Unlock() => isActive = true;

}
