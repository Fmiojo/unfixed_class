using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_HitKill : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.GameOver();
        }
    }
}
