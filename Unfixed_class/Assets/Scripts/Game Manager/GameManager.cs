using System;
using System.Collections;
using System.Dynamic;
using UnityEditor.Networking.PlayerConnection;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum Classes{Base ,Warrior, Thief, Mage}
    public Classes CurrentClass
    {
       get;set;
    }
    public enum Enviroments{Forest,City,Dungeon}
    public Enviroments CurrentEnviroment
    {
       get;set;
    }
    public bool Paused
    {
        get;set;
    }
    
    public bool Invincible
    {
       get;set;
    }
    public bool Danger
    {
        get;set;
    }
    public float Speed
    {
        get;set;
    }
    public GameObject Player
    {
        get;set;
    }
    public GameObject Floor
    {
        get;set;
    }
    public static float [] tilesPos;
    [SerializeField]
    public float InvincibleTime
    {
        get;set;
    }
    [SerializeField]
    public float DangerTime
    {
        get;set;
    }
    float tileSize;
    int i; 
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        NewGame();
    }
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Paused == false)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
    }
    public void Pause()
    {
        Paused = true;
        Time.timeScale = 0;
        HUD.hud.Pause();
    }
    public  void Unpause()
    {
        Paused = false;
        Time.timeScale = 1;
        HUD.hud.UnPause();
    }
    public void IncreaseSpeed()
    {
        Speed = Speed * 1.1f;
    }
    public void GameOver()
    {
       Time.timeScale = 0;
       Paused = true;
       HUD.hud.GameOver();
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene("mainScene");
    }
    public void NewGame()
    {
        instance.Speed = 10;
        instance.DangerTime = 6;
        instance.InvincibleTime = 1;
        instance.CurrentEnviroment = Enviroments.Forest;
        Unpause();
        instance.InvokeRepeating("IncreaseSpeed",0,30);
        instance.Danger = false;
        instance.Invincible = false;
    }
    public void GetTilePos(int tiles)
   {
       tilesPos = new float [tiles];
       tileSize = Floor.transform.localScale.x/3;
       for(i = 0; i < tilesPos.Length; i++)
       {    
           tilesPos[i] = 0 + ((i-1) * tileSize);
       }
   }
}
