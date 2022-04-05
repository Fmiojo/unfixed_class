using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLife : MonoBehaviour
{
   [SerializeField]
   float invincibleTime;
   [SerializeField]
   float vulnerableTime;
   public void Vulnerable()
   {
      StartCoroutine(HitEffect());
   }
   public void Death()
   {
       
   }
   IEnumerator HitEffect()
   {
      GameManager.invincible = true;
      float i = 0;
      while(i <= invincibleTime)
      {
        i += Time.fixedDeltaTime;
        yield return null;
      }
   }
}
