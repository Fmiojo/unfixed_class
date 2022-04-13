using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_HitDanger : MonoBehaviour
{
     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == GameManager.instance.Player)
        {
            if(GameManager.instance.Danger == true)
            {
                GameManager.instance.GameOver();
            }
            else
            {
                GameManager.instance.DangerCicleStart();
                GameManager.instance.InvincibleCicleStart();
                playerLife.instance.Danger();
                playerMove.instance.CorrectPos((int)playerMove.instance.playerTile);
            }
        }
    }
}
