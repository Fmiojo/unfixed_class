using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_HitKill : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
    {
        if(GameManager.instance.Invincible == true)
        {
            return;
        }
        if(other.gameObject == GameManager.instance.Player)
        {
            GameManager.instance.GameOver();
        }
    }
}
