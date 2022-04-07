using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleScenario : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
   {
       if(other.CompareTag("CenarioDestroyer"))
       {
           Explode();
       }
   }
   public void Explode()
   {
       Destroy(gameObject);
   }
}
