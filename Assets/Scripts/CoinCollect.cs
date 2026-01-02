using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CoinCollect : MonoBehaviour
{
    public static UnityEvent playCollectSound = new UnityEvent();
   private void OnTriggerEnter2D(Collider2D other) 
   {
    if(other.gameObject.tag == "Player")
    {
        GameControl.instance.CoinCollected();
        playCollectSound.Invoke();
        gameObject.SetActive(false);
        Destroy(gameObject, 1);
    }    
   }
}
