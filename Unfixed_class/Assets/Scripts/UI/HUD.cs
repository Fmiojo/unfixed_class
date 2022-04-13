using System.Collections;
using System;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;
    [SerializeField]
    GameObject gameOverMenu;
    [SerializeField]
    GameObject PreGameMenu;
    public static HUD instance;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PreGame()
    {
        PreGameMenu.SetActive(true);
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
    }
    public void UnPause()
    {
        pauseMenu.SetActive(false);
    }
    public  void GameOver()
    {
        gameOverMenu.SetActive(true);
    }
}
