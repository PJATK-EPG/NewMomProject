using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMathfClamp
{
    public static float Clamp(float value, float[] boarders)
    {
        float outputValue=value;
        if(boarders[0]!=-360 && boarders[1]!=360)
        {
            if (boarders[0] >= 0 && boarders[1] >= 0)
            {
                outputValue = PositivePositive(value, boarders);
            }
            else if (boarders[0] < 0 && boarders[1] >= 0)
            {
                outputValue = NegativePositive(value, boarders);
            }
            else if (boarders[0] < 0 && boarders[1] < 0)
            {
                outputValue = NegativeNegative(value, boarders);
            }  
        }
        return outputValue;
    }
    private static float PositivePositive(float value, float[] boarders)
    {
        if (value < boarders[0])
            value = boarders[0];
        if (value > boarders[1])
            value = boarders[1];
        return value;
    }
    private static float NegativePositive(float value, float[] boarders)
    {
        float newLowBoarder = 360 + boarders[0];
        float nearestBorder = FindNearest(value, newLowBoarder, boarders[1]);
        if (value < newLowBoarder && !(value >= 0 && value <= boarders[1]) && newLowBoarder == nearestBorder)
        {
            value = newLowBoarder;
        }
        else if (value > boarders[1] && !(value >= newLowBoarder && value < 360) && boarders[1] == nearestBorder)
        {
            value = boarders[1];
        }
        return value;
    }

    private static float FindNearest(float value, float border1, float border2)
    {
        float answer = 0;
        float firstDistance = Mathf.Pow(border1 - value, 2);
        float secondDistance = Mathf.Pow(border2 - value, 2);
        if (firstDistance > secondDistance)
        {
            answer = border2;
        }
        else
        {
            answer = border1;
        }
        return answer;
    }

    private static float NegativeNegative(float value, float[] boarders)
    {
        float[] newBoarders = new float[2] { 360 - boarders[0], 360 - boarders[1] };
        if (value < newBoarders[0])
            value = newBoarders[0];
        if (value > newBoarders[1])
            value = newBoarders[1];
        return value;
    }
}
