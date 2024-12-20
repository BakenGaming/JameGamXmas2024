using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyCane : MonoBehaviour, ICollectable
{
    public static event Action<float> OnCandyCaneCollected;
    private LootSO lootStats;
    public void Initialize(LootSO _lootStats)
    {
        lootStats = _lootStats;
    }
    public void Collect()
    {
        OnCandyCaneCollected?.Invoke((float)lootStats.value);
        Destroy(gameObject);
    }

    public void SetTarget(Vector3 targetPosition)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, lootStats.attractSpeed * Time.deltaTime);
    }
}
