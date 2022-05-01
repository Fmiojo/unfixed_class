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
    public float [] tilesPos;
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
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }
        Time.timeScale = 1f;
        instance.Invoke("PreGame",2f);
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
        MusicManager.instance.Pause();
        HUD.instance.Pause();
    }
    public  void Unpause()
    {
        Paused = false;
        Time.timeScale = 1;
        MusicManager.instance.Play();
        HUD.instance.UnPause();
    }
    public void IncreaseSpeed()
    {
        Speed = Speed * 1.1f;
    }
    public void GameOver()
    {
       Time.timeScale = 0;
       Paused = true;
       MusicManager.instance.Stop();
       HUD.instance.GameOver();
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene("mainScene");
    }
    public void PreGame()
    {
        instance.Speed = 0;
        instance.Paused = true;
        CameraMove.instance.PreGameSet();
        HUD.instance.PreGame();
        playerInputs.instance.InputsOn = true;
    }
    public void NewGame()
    {
        EnviromentChanger.instance.ChangeEnviroment(Enviroments.Forest);
        EnviromentChanger.instance.Invoke("StartVariation",EnviromentChanger.instance.MinEnviromentTime);
        instance.Paused = false;
        CameraMove.instance.NewGame();
        HUD.instance.NewGame();
        instance.Speed = 10;
        instance.DangerTime = 6;
        instance.InvincibleTime = 1;
        instance.InvokeRepeating("IncreaseSpeed",0,20);
        instance.Danger = false;
        instance.Invincible = false;
        PowerUpSpawner.instance.Invoke("StartRegularSpawning",1f);
        ObstacleSpawner.instance.Invoke("StartRegularSpawning",1f);
        MusicManager.instance.Play();
    }
    public void GetTilePos(int tiles)
   {
       tilesPos = new float [tiles];
       tileSize = Floor.transform.localScale.x/3;
       for(i = 0; i < tilesPos.Length; i++)
       {    
           tilesPos[i] = 0 + ((i-(tiles/2)) * tileSize);
       }
   }
}
