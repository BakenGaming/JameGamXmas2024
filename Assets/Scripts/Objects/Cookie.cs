using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cookie : MonoBehaviour, ICollectable
{
public static event Action<int> OnCookieCollected;
    private LootSO lootStats;
    public void Initialize(LootSO _lootStats)
    {
        lootStats = _lootStats;
    }
    public void Collect()
    {
        OnCookieCollected?.Invoke(lootStats.value);
        Destroy(gameObject);
    }

    public void SetTarget(Vector3 targetPosition)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, lootStats.attractSpeed * Time.deltaTime);
    }
}
