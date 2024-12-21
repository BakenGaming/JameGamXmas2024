using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileType
{
    snowball, present, cookie
}
[CreateAssetMenu(menuName = "Projectile")]
public class ProjectileSO : ScriptableObject
{
    public string projectileName;
    public ProjectileType projectileType;
    public Sprite[] projectileSprite;
    public float projectileSpeed;
    public float lifeTime;
}
