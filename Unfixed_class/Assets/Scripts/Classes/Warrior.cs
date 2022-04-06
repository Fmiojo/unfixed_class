using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Warrior : PowerUps
{   
    [SerializeField]
    GameObject warriorShield;
    [SerializeField]
    float shieldDuration;
    public override void PowerUp()
    {
        if((skillReady == false)||(playerMove.instance.GetGrounded() == false))
        {
            Debug.Log("Coxinha");
            return;
        }
        else
        {
            GameManager.Setcoroutines(false);
            skillReady = false;
            StartCoroutine(CoolDown(this.coolDownTime));
            warriorShield.SetActive(true);
            GameManager.SetSpeed(GameManager.speed * 3);
            Invoke("EndPowerUp",shieldDuration);
        }
    }
    void EndPowerUp()
    {
        GameManager.SetSpeed(GameManager.speed/3);
        warriorShield.SetActive(false);
        GameManager.Setcoroutines(true);
    }
}
