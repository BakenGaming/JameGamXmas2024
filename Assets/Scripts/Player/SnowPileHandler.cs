using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowPileHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D _collider) 
    {
        IHandler newHandler = _collider.gameObject.GetComponent<IHandler>();
        if(newHandler != null)
        {
            newHandler.SlowMomentum();
        }    
    }
}
