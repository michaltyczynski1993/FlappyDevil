using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour
{
    public static CoinPool instance;
    public GameObject coin;
    private float minPos = -2.4f;
    private float maxPos = 3.2f;
    private float spawnXPosition = 10f;
    private float timeSinceLastSpawned;
    public float spawnRate = 9f;
    
    void Awake() {
		if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if (instance != this)
            //...destroy this one because it is a duplicate.
            Destroy(gameObject);
	}

    void Start()
    {
        timeSinceLastSpawned = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

		if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) 
		{	
			timeSinceLastSpawned = 0f;

			//Set a random y position for the column
			float spawnYPosition = Random.Range(minPos, maxPos);
            Instantiate(coin, new Vector2(spawnXPosition,spawnYPosition),Quaternion.identity);
		}
    }
}
