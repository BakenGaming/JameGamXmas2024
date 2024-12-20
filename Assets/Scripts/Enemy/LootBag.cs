using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    [SerializeField] private List<LootSO> availableLoot;
    [SerializeField] private LootSO defaultItem;

    private LootSO dropItem;
    public void DropLoot()
    {
        int randomChance = Random.Range(0,101);
        foreach(LootSO loot in availableLoot)
        {
            if (randomChance <= loot.dropChance)
            {
                dropItem = loot;
                break;
            }
        }

        if (dropItem != null)
        {
            GameObject newItem = Instantiate(dropItem.lootGO, transform.position, Quaternion.identity);
            newItem.GetComponent<ICollectable>().Initialize(dropItem);
        }
        else
        {
            GameObject newItem = Instantiate(defaultItem.lootGO, transform.position, Quaternion.identity);
            newItem.GetComponent<ICollectable>().Initialize(dropItem);
        }

    }
}
