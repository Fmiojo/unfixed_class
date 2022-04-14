using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentChanger : MonoBehaviour
{
    [SerializeField]
    float minEnviromentTime;
    [SerializeField]
    float maxEnviromentTime;
    public bool Stop
    {
        get;set;
    }
   void Awake()
   {
       Invoke("StartVariation",2f);
   }
   IEnumerator EnviromentVariation()
   {
        while(Stop == false)
        {
            float time = UnityEngine.Random.Range(minEnviromentTime,maxEnviromentTime);
            int size = Enum.GetNames(typeof(GameManager.Enviroments)).Length;
            GameManager.Enviroments targetEnviroment = (GameManager.Enviroments)UnityEngine.Random.Range(0,size);
            ChangeEnviroment(targetEnviroment);
            yield return new WaitForSeconds(time);
        }
        yield break;       
   }
   public void ChangeEnviroment(GameManager.Enviroments targetEnviroment)
   {
       GameManager.instance.CurrentEnviroment = targetEnviroment;
       ObstacleSpawner.instance.Invoke("SetType",100/GameManager.instance.Speed);
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
