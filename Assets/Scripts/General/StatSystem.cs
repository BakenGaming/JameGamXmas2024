using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class StatSystem
{
    private float moveSpeed, timeBetweenShots, timeBetweenThrows, boostAmount;
    private int health, cookieMax, presentMax;

    public StatSystem (PlayerStatsSO _stats)
    {
        health = _stats.health;
        moveSpeed = _stats.moveSpeed;
        timeBetweenShots = _stats.timeBetweenShots;
        timeBetweenThrows = _stats.timeBetweenThrows;
        boostAmount = _stats.boostAmount;
        cookieMax = _stats.cookieMax;
        presentMax = _stats.presentMax;
    }

    public int GetPlayerHealth (){return health;}
    public float GetMoveSpeed(){return moveSpeed;}
    public float GetTimeBetweenShots(){return timeBetweenShots;}
    public float GetTimeBetweenThrows(){return timeBetweenThrows;}
    public float GetBoostAmount(){return boostAmount;} 
    public int GetCookieMax(){return cookieMax;}
    public int GetPresentMax(){return presentMax;}
}
