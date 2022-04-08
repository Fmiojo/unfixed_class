using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
   public static GameManager instance;
   public enum Classes{Base ,Warrior, Thief, Mage}
   public static Classes currentClass;
   public enum Enviroments{Forest,City,Dungeon}
   public static Enviroments currentEnviroment;
   public static bool paused;
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
   static bool coroutinesRunning = true;
   public static bool specialEvent = false;
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
        ChangeClass(Classes.Base);
        NewGame();
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
    public static void ChangeClass()
    {
        int randomIndex = UnityEngine.Random.Range(0,Enum.GetValues(typeof(Classes)).Length);
        currentClass = (Classes)randomIndex;
        PlayerClassChange.ChangeClass((Classes)randomIndex);
    }
    public static void ChangeClass(Classes targetClass)
    {
        currentClass = targetClass;
        PlayerClassChange.ChangeClass(targetClass);
    }
    public static void ChangeEnviroment(Enviroments targetEnviroment)
    {
        if(specialEvent == true)
        {
            return;
        }
        currentEnviroment = targetEnviroment;
    }
    public static void ChangeEnviroment()
    {
        if(specialEvent == true)
        {
            return;
        }
        currentEnviroment = (Enviroments)UnityEngine.Random.Range(0, Enum.GetValues(typeof(Enviroments)).Length);
    }
    public static void SetSpeed(float targetSpeed)
    {
        speed = targetSpeed;
    }  
    public static IEnumerator IncreaseSpeedOverTime(float transitionTime,float speedIncrease,float maxSpeed)
   {
       while(speed < maxSpeed)
       {
           float lastSpeed = speed;
           float targetSpeed = speed * speedIncrease;
           float t = 0;
           while(t<1)
           {
               if(coroutinesRunning == false)
               {
                   yield return null;
               }
               t += Time.fixedDeltaTime/transitionTime;
               t = Mathf.Clamp(t,0,1);
               speed = Mathf.Lerp(lastSpeed,targetSpeed,t);
               yield return null;
           }
           speed = Mathf.Clamp(speed,0,maxSpeed);
           yield return new WaitForSeconds(5f);   
       }
       yield break;
   }
    public static void Danger()
    {
    
    }
    public static void GameOver()
    {
       Time.timeScale = 0;
       paused = true;
       HUD.hud.GameOver();
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene("mainScene");
    }
    public void NewGame()
    {
        SetSpeed(inicialSpeed);
        GetPlayerRef();
        GetTilePos();
        ChangeEnviroment(Enviroments.Forest);
        Time.timeScale = 1;
        Unpause();
        StartCoroutine(IncreaseSpeedOverTime(10,1.1f,inicialSpeed*5));
    }
    public static void Setcoroutines(bool run)
    {
        coroutinesRunning = run;
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
