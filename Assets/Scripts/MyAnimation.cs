using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MyAnimationType
{
    PositionAnim,
    ColorAnim,
}

public class MyAnimation : MonoBehaviour
{
    [SerializeField] public MyAnimationType animationType;

    [SerializeField] public Transform body;
    [SerializeField] public Image image;

    [SerializeField] public Transform finishPoint;
    [SerializeField] public Color finishColor;

    [SerializeField] public float speedOfAnimation;
    [SerializeField] public float accuracy;

    
}
