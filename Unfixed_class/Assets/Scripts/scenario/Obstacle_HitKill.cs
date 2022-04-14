using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_HitKill : MonoBehaviour
{
   void OnCollisionEnter(Collision other)
    {
        if(GameManager.instance.Invincible == false)
        {
            if(other.gameObject == GameManager.instance.Player)
            {
                GameManager.instance.GameOver();
            }
        }
    }
}
