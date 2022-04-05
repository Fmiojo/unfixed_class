using System.Collections;
using System;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;
    [SerializeField]
    GameObject gameOverMenu;
    public static HUD hud;
    void Awake()
    {
        if(hud == null)
        {
            hud = this;
        }
        else
        {
            Destroy(gameObject);
        }
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
