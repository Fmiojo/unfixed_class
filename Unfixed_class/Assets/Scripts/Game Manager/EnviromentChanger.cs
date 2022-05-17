using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentChanger : MonoBehaviour
{
    public static EnviromentChanger instance;
    [SerializeField]
    public float MinEnviromentTime;

    [SerializeField]
    public float MaxEnviromentTime;
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
        MinEnviromentTime = 10f;
        MaxEnviromentTime = 12f;
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
        GameManager.Enviroments targetEnvironment = (GameManager.Enviroments)UnityEngine.Random.Range(0,Enum.GetNames(typeof(GameManager.Enviroments)).Length);
        while(targetEnvironment == GameManager.instance.CurrentEnviroment)
        {
            targetEnvironment = (GameManager.Enviroments)UnityEngine.Random.Range(0,Enum.GetNames(typeof(GameManager.Enviroments)).Length);
        }
        GameManager.instance.CurrentEnviroment = targetEnvironment;
        Debug.Log(GameManager.instance.CurrentEnviroment);
        ObstacleSpawner.instance.SetType();
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
