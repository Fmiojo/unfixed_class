using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_HitDanger : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {

        if(other.gameObject == GameManager.instance.Player)
        {
            if(GameManager.instance.Invincible == false)
            {
                if(GameManager.instance.Danger == true)
                {
                    GameManager.instance.GameOver();
                }
                else
                {
                    playerLife.instance.DangerInvincible();
                    playerMove.instance.CorrectPos((int)playerMove.instance.playerTile);
                }
            }
        }
    }
}
