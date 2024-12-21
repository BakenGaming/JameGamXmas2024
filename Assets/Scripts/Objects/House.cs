using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Sprite[] availableHouses;

    private void Start() 
    {
        GetComponent<SpriteRenderer>().sprite = availableHouses[Random.Range(0, availableHouses.Length)];    
    }
    public void DeliverPresent()
    {
        Debug.Log("Present Delievered");
    }
}
