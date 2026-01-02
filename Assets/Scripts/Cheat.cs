using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePix;

public class Cheat : MonoBehaviour
{
    private int coins;
    private int currentCoins;
    [SerializeField] private GameObject rewardInfoPanel;
    void Start()
    {
        currentCoins = PlayerPrefs.GetInt("CoinCount");
    }

    public void AddCoins()
    {
        // tu wyświetl reward Ads -> coins powinny zostać dodane po wyświetleniu reklamy
        Gpx.Ads.RewardAd(OnRewardAdsSuccess);
        
    }
    void OnRewardAdsSuccess()
    {
        // Dodaj 15 coins dopiero po wyświetleniu reklamy
        Debug.Log("Rewarded Ads Load SUCCESS");
        coins = currentCoins + 15;
        PlayerPrefs.SetInt("CoinCount", coins);
        rewardInfoPanel.SetActive(true);
        

    }
    public void ResetSkins()
    {
        PlayerPrefs.DeleteKey("isFirstSkinBought");
        PlayerPrefs.DeleteKey("isSecondSkinBought");
        PlayerPrefs.DeleteKey("isThirdSkinBought");
        PlayerPrefs.DeleteKey("isFourthSkinBought");
        PlayerPrefs.DeleteKey("currentSkin");
    }
}
