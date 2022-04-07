using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObstacles : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
   {
       if(other.CompareTag("Obstacle"))
       {
           gameObject.SetActive(false);
       }
   }
}
