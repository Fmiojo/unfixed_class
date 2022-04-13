using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication;
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
      }
      else
      {
         Destroy(gameObject);
      }
   }
   void Start()
   {
      GameManager.instance.Player = this.gameObject;
   }
   public void DangerInvincible()
   {
      StartCoroutine(HitColors());
   }
   IEnumerator HitColors()
   {
      GameManager.instance.Danger = true;
      GameManager.instance.Invincible = true;
      float t = 0;
      Color inicialColor = gameObject.GetComponent<MeshRenderer>().material.color;
      Color dangerColorMax = Color.black;
      Color dangerColor;
      Color invincibleColorMax = new Color(0,0,0,0);
      Color invicibleColor;
      Color targetColor; 
      while(t <= GameManager.instance.DangerTime)
      {
         while(t <= GameManager.instance.InvincibleTime)
         {
            t+= Time.deltaTime;
            dangerColor = Color.Lerp(inicialColor,dangerColorMax,Mathf.PingPong(t,1));
            invicibleColor = Color.Lerp(inicialColor,invincibleColorMax,Mathf.PingPong(t*8,1));
            targetColor = invicibleColor + dangerColor/2;
            gameObject.GetComponent<MeshRenderer>().material.color = targetColor;
            yield return null;
         }
         t+= Time.fixedDeltaTime;
         GameManager.instance.Invincible = false;
         dangerColor = Color.Lerp(inicialColor,dangerColorMax,Mathf.PingPong(t,1));
         targetColor = dangerColor;
         gameObject.GetComponent<MeshRenderer>().material.color = targetColor;
         yield return null;
      }
      GameManager.instance.Danger = false;
      Debug.Log("Fim do ciclo");
      yield break;
   }
}
