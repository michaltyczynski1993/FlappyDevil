using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollect : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other) 
   {
    if(other.gameObject.tag == "Player")
    {
        GameControl.instance.CoinCollected();
        gameObject.SetActive(false);
        Destroy(gameObject);
    }    
   }
}
