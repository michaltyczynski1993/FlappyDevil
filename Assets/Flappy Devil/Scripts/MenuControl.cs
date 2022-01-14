using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public AudioSource audioSource;
    private float audioTimer;
    private void Start() 
    {
        audioTimer = audioSource.clip.length;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
     public void RestartLevel()
    {
        StartCoroutine(LoadCurrentLevelTimer(audioTimer));
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameControl.instance.nextLevel = false;
    }
    IEnumerator LoadCurrentLevelTimer(float audioTimer)
    {
        yield return new WaitForSeconds(audioTimer);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
      public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Store()
    {
        SceneManager.LoadScene("Store");
    }
}
