using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLife : MonoBehaviour
{
   public static playerLife playerInstance;
   [SerializeField]
   int dangerTicks;
   [SerializeField]
   int invincibleTicks;
   
   void Awake()
   {
      if(playerInstance == null)
      {
         playerInstance = this;
      }
      else
      {
         Destroy(gameObject);
      }
   }
   public void Danger(float time)
   {
      //StartCoroutine(InvincibleColor());
      StartCoroutine(DangerColor(time));
   }
   /*IEnumerator InvincibleColor()
   {
      Material inicialColor = gameObject.GetComponent<MeshRenderer>().material;
      Material finalColor = inicialColor;
      finalColor.color = Color.black;
   }*/
   IEnumerator DangerColor(float time)
   {
      Material inicialColor = gameObject.GetComponent<MeshRenderer>().material;
      Material finalColor = inicialColor;
      finalColor.color = Color.black;
      float t = 0;
      while(t <= time)
      {      
         gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(inicialColor.color,finalColor.color, Mathf.PingPong(t,1));
         t += Time.fixedDeltaTime;
         yield return null;
      }
      yield break;
   }

}
