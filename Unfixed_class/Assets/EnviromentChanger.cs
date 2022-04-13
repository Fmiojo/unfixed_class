using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentChanger : MonoBehaviour
{
    [SerializeField]
    float minEnviromentTime;
    [SerializeField]
    float maxEnviromentTime;
    bool stop = false;
   void Start()
   {
       StartChanging();
   }
   IEnumerator ChangeEnviroment(float minTime, float maxTime)
   {
       while(stop == false)
       {
            float time = UnityEngine.Random.Range(minTime, maxTime);
            GameManager.instance.CurrentEnviroment = GameManager.Enviroments.Forest;
            yield return new WaitForSeconds(time);
       }
       yield break;
   }
   void StopChanging()
   {
       stop = true;
   }
   void StartChanging()
   {
       stop = false;
       StartCoroutine(ChangeEnviroment(minEnviromentTime,maxEnviromentTime));
   }
}
