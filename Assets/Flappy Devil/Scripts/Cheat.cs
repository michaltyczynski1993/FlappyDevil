using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    private int coins;
    private int currentCoins;
    void Start()
    {
        currentCoins = PlayerPrefs.GetInt("CoinCount");
    }

    public void AddCoins()
    {
        coins = currentCoins + 500;
        PlayerPrefs.SetInt("CoinCount", coins);
        
    }
    public void ResetSkins()
    {
        PlayerPrefs.DeleteKey("isFirstSkinBought");
        PlayerPrefs.DeleteKey("isSecondSkinBought");
        PlayerPrefs.DeleteKey("currentSkin");
    }
}
