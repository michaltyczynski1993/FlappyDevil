using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreControl : MonoBehaviour
{
    //Skin 1 variables
    private int firstCost = 0;
    private bool isFirstBought = true;
    private int coins;
    public Text firstSkinButtonText;
    //Skin 2 variables
    private int secondCost = 300;
    private bool isSecondBought;
    public Text secondSkinButtonText;

    private int currentSkin;

    void Start()
    {
        PlayerPrefs.SetInt("isFirstSkinBought", isFirstBought ? 1:0);
        isFirstBought = PlayerPrefs.GetInt("isFirstSkinBought")==1;
        isSecondBought = PlayerPrefs.GetInt("isSecondSkinBought")==1;
        coins = PlayerPrefs.GetInt("CoinCount");
        currentSkin = PlayerPrefs.GetInt("currentSkin");
        CurrentSkin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FirstSkin()
    {
        if(isFirstBought)
        {
           PlayerPrefs.SetInt("currentSkin", currentSkin);
           firstSkinButtonText.text = "Selected";

        }
        else
        {
            if (coins >= firstCost)
            {
                coins = coins-firstCost;
                PlayerPrefs.SetInt("CoinCount", coins);
                GameControl.instance.coinNumber.text = PlayerPrefs.GetInt("CoinCount").ToString();
                isFirstBought = true;
                PlayerPrefs.SetInt("isFirstSkinBought", isFirstBought ? 1 : 0);
                firstSkinButtonText.text = "Select";
            }
        }
    }
    public void SecondSkin()
    {
        if(isSecondBought)
        {
           PlayerPrefs.SetInt("currentSkin", currentSkin);
           secondSkinButtonText.text = "Selected";

        }
        else
        {
            if (coins >= secondCost)
            {
                coins = coins-secondCost;
                PlayerPrefs.SetInt("CoinCount", coins);
                GameControl.instance.coinNumber.text = PlayerPrefs.GetInt("CoinCount").ToString();
                isSecondBought = true;
                PlayerPrefs.SetInt("isSecondSkinBought", isSecondBought ? 1 : 0);
                secondSkinButtonText.text = "Select";
            }
        }
    }
    public void CurrentSkin()
    {
        if(currentSkin == 0)
        {
            firstSkinButtonText.text = "Selected";
        }
        if(currentSkin == 1)
        {
            firstSkinButtonText.text = "Selected";
        }
    }
}
