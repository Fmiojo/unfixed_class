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
    [SerializeField]
    GameObject MainHUD;
    public static HUD instance;
    void Awake()
    {
        instance = this;
    }
    public void PreGame()
    {
        instance.PreGameMenu.SetActive(true);
    }
    public void NewGame()
    {
        PreGameMenu.SetActive(false);
        MainHUD.SetActive(true);
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
