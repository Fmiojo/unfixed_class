using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObstacles : MonoBehaviour
{
   [SerializeField]
   AudioSource shieldSound;
   void OnTriggerEnter(Collider other)
   {
       if(other.CompareTag("Obstacle"))
       {
           shieldSound.Play();
           gameObject.SetActive(false);
       }
   }
}
