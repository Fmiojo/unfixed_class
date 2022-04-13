using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLife : MonoBehaviour
{
   public static playerLife instance;
   [SerializeField]
   int dangerTicks;
   [SerializeField]
   int invincibleTicks;
   
   void Awake()
   {
      if(instance == null)
      {
         instance = this;
         GameManager.instance.Player = this.gameObject;
      }
      else
      {
         Destroy(gameObject);
      }
   }
   public void Danger()
   {
      //StartCoroutine(InvincibleColor());
      StartCoroutine(DangerColor());
   }
   /*IEnumerator InvincibleColor()
   {
      Material inicialColor = gameObject.GetComponent<MeshRenderer>().material;
      Material finalColor = inicialColor;
      finalColor.color = Color.black;
   }*/
   IEnumerator DangerColor()
   {
      Color inicialColor = gameObject.GetComponent<MeshRenderer>().material.color;
      Color finalColor = Color.black;
      float t = 0;
      while(t <= GameManager.instance.DangerTime)
      {      
         t += Time.fixedDeltaTime;
         gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(inicialColor,finalColor, Mathf.PingPong(t,1));
         yield return null;
      }
      yield break;
   }

}
