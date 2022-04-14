using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentChanger : MonoBehaviour
{
    public static EnviromentChanger instance;
    [SerializeField]
    public float MinEnviromentTime
    {
        get;set;
    }
    [SerializeField]
    public float MaxEnviromentTime
    {
        get;set;
    }
    public bool Stop
    {
        get;set;
    }
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        MinEnviromentTime = 20f;
        MaxEnviromentTime = 60;
    }
   IEnumerator EnviromentVariation()
   {
        while(Stop == false)
        {
            float time = UnityEngine.Random.Range(MinEnviromentTime,MaxEnviromentTime);
            ChangeEnviroment();
            yield return new WaitForSeconds(time);
        }
        yield break;       
   }
   public void ChangeEnviroment()
   {
        GameManager.instance.CurrentEnviroment = (GameManager.Enviroments)UnityEngine.Random.Range(0,Enum.GetNames(typeof(GameManager.Enviroments)).Length);
   }
   public void ChangeEnviroment(GameManager.Enviroments targetEnviroment)
   {
       GameManager.instance.CurrentEnviroment = targetEnviroment;
       ObstacleSpawner.instance.SetType();
   }
   public void StartVariation()
   {
       Stop = false;
       StartCoroutine(EnviromentVariation());
   }
   public void StopVariation()
   {
       Stop = true;
   }
}
