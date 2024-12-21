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
            if(dropItem.lootType == LootType.candyCane)
            {
                CandyCane newCandyCaneLoot = ObjectPooler.DequeueObject<CandyCane>("CandyCane");
                newCandyCaneLoot.transform.position = transform.position;
                newCandyCaneLoot.gameObject.SetActive(true);
                newCandyCaneLoot.Initialize(dropItem);
            }

            if(dropItem.lootType == LootType.cookies)
            {
                Cookie newCookieLoot = ObjectPooler.DequeueObject<Cookie>("CookieRefill");
                newCookieLoot.transform.position = transform.position;
                newCookieLoot.gameObject.SetActive(true);
                newCookieLoot.Initialize(dropItem);
            }
        }
        else
        {
            if(defaultItem.lootType == LootType.candyCane)
            {
                CandyCane newCandyCaneLoot = ObjectPooler.DequeueObject<CandyCane>("CandyCane");
                newCandyCaneLoot.transform.position = transform.position;
                newCandyCaneLoot.gameObject.SetActive(true);
                newCandyCaneLoot.Initialize(defaultItem);
            }

            if(defaultItem.lootType == LootType.cookies)
            {
                Cookie newCookieLoot = ObjectPooler.DequeueObject<Cookie>("CookieRefill");
                newCookieLoot.transform.position = transform.position;
                newCookieLoot.gameObject.SetActive(true);
                newCookieLoot.Initialize(defaultItem);
            }
        }

    }
}
