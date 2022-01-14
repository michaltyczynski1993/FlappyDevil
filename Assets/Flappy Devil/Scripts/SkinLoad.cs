using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinLoad : MonoBehaviour
{
    private int currentSkin;
    public GameObject[] skins;
    private GameObject player;
    private void Awake() 
    {
        currentSkin = PlayerPrefs.GetInt("currentSkin");
        player = this.gameObject;
    }
    void Start()
    {
        LoadSkin();
    }
    void LoadSkin()
    {
        
        Instantiate(skins[currentSkin], player.transform);
    }
}
