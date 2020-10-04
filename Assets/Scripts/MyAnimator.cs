using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyAnimator : MonoBehaviour
{
    public static MyAnimator Instance { get; private set; }

    private MyAnimationType animationType;
    private Transform body;
    private Image image;

    private Vector3 finishPoint;
    private Color finishColor;

    private float speedOfAnimation;
    private float accuracy;

    private bool canAnimate;

    private void Awake()
    {
        Instance = this;
    }
    
    public void ProcessAnimation(MyAnimation animation)
    {
        animationType = animation.animationType;
        if(animationType == MyAnimationType.PositionAnim)
        {
            body = animation.body;
            finishPoint = animation.finishPoint.position;
        }
        else if(animationType == MyAnimationType.ColorAnim)
        {
            image = animation.image;
            finishColor = animation.finishColor;
        }
        speedOfAnimation = animation.speedOfAnimation;
        accuracy = animation.accuracy;
        canAnimate = true;
    }

    public void Update()
    {
        if(canAnimate) 
        { 
            if(animationType == MyAnimationType.PositionAnim)
            {
                MakePositionAnim();
            }
            else if(animationType == MyAnimationType.ColorAnim)
            {
                MakeColorAnim();
            }
        }
    }

    private void MakePositionAnim()
    {
        if (canAnimate)
        {
            if (Vector3.Distance(body.position, finishPoint) < accuracy)
            {
                body.position = Vector3.MoveTowards(body.position, finishPoint, speedOfAnimation * Time.deltaTime);
            }
            else
            {
                canAnimate = false;
            }
        }
    }

    private void MakeColorAnim()
    {
        if (canAnimate)
        {
            if (Mathf.Abs(image.color.a - finishColor.a) > accuracy)
            { 
                if(image.color.a > finishColor.a)
                {
                    float newAlpha = image.color.a - speedOfAnimation * Time.deltaTime;
                    image.color = new Color( image.color.r, image.color.g, image.color.b, newAlpha);
                }
                else
                {
                    float newAlpha = image.color.a + speedOfAnimation * Time.deltaTime;
                    image.color = new Color(image.color.r, image.color.g, image.color.b, newAlpha);
                }    
            }
            else
            {
                canAnimate = false;
            }
        }
    }


}
