using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSystem
{
    private int maxCount;
    private float baseMoveSpeed;
    private float clickTimer;

    public StatSystem (GameStats _stats)
    {
        maxCount = _stats.maxCount;
        baseMoveSpeed = _stats.baseMoveSpeed;
        clickTimer = _stats.clickTimer;

    }

    public int GetMaxCount (){return maxCount;}
    public float GetBaseMoveSpeed(){return baseMoveSpeed;}
    public float GetClickTimer(){return clickTimer;}
}
