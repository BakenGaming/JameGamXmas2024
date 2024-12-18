using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Game Stats")]
public class GameStats : ScriptableObject
{
    public int maxCount;
    public float baseMoveSpeed;
    public float clickTimer;
}
