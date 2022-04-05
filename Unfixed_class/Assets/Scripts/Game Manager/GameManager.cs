using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;
   public enum Classes{Base ,Warrior, Thief}
   public static Classes currentClass;
   public enum Enviroments{Forest,City,Dungeon}
   public static Enviroments currentEnviroment;
   public static bool paused;
   [SerializeField]
   Camera mainCamera;
   [SerializeField]
   public static GameObject player;
   GameObject floor;
   public static float [] tilesPos;
   [SerializeField]
   public static float speed = 0;
   [SerializeField]
   float inicialSpeed;
   float tileSize;
   public static bool vulnerable = false;
   public static bool invincible = false;
   int i; 
   void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(gameObject);
        SetSpeed(inicialSpeed);
        GetPlayerRef();
        GetTilePos();
        ChangeEnviroment(Enviroments.Forest);
    }
    public static void ChangeClass()
    {
        currentClass = (Classes)UnityEngine.Random.Range(0,Enum.GetValues(typeof(Classes)).Length);
    }
    public static void ChangeClass(Classes targetClass)
    {
        currentClass = targetClass;
        PlayerClassChange.ChangeClass(targetClass);
    }
    public static void ChangeEnviroment(Enviroments targetEnviroment)
    {
        currentEnviroment = targetEnviroment;
    }
    public static void ChangeEnviroment()
    {
        currentEnviroment = (Enviroments)UnityEngine.Random.Range(0, Enum.GetValues(typeof(Enviroments)).Length);
    }
    public static void IncreaseSpeed()
    {
       speed = speed * 1.1f;
    }
    public static void GameOver()
    {
       Time.timeScale = 0;
       paused = true;
       HUD.hud.GameOver();
    }
    public void NewGame()
    {
       SceneManager.LoadScene("mainScene");
       Time.timeScale = 1;
       Unpause();
    }
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused == false)
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
        Time.timeScale = 0;
        HUD.hud.Pause();
        paused = true;
    }
    public void Unpause()
    {
        Time.timeScale = 1;
        HUD.hud.UnPause();
        paused = false;
    }
    void GetPlayerRef()
    {
        player = GameObject.FindWithTag("Player");
        tilesPos = new float[3];
    }
    public static void SetSpeed(float targetSpeed)
    {
        speed = targetSpeed;
    }
   IEnumerator SetSpeedOvertime(float targetSpeed, float transitionTime)
   {
       float lastSpeed = speed;
       float i = 0;
       while(i <= 1)
       {
           speed = Mathf.Lerp(lastSpeed, targetSpeed, i);
           i += Time.fixedDeltaTime;
           yield return null;
       }
       StopCoroutine(SetSpeedOvertime(targetSpeed, transitionTime));
   }
   void GetTilePos()
   {
       floor = GameObject.FindGameObjectWithTag("Floor");
       tileSize = floor.transform.localScale.x/3;
       for(i = 0; i < 3; i++)
       {    
           tilesPos[i] = 0 + ((i-1) * tileSize);
       }
   }
}
