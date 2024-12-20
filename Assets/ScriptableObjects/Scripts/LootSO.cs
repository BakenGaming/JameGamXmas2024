using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LootType
{
    milk, cookies, candyCane
}
[CreateAssetMenu(menuName = "Loot")]
public class LootSO : ScriptableObject
{
    public LootType lootType;
    public GameObject lootGO;
    public int dropChance;
    public int value;
    public float attractSpeed;
}
