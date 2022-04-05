using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Warrior : PowerUps
{   
    [SerializeField]
    GameObject warriorShield;
    public override void PowerUp()
    {
        warriorShield.SetActive(true);
        GameManager.SetSpeed(GameManager.speed * 3);
        Invoke("EndPowerUp", 0.5f);
    }
    void EndPowerUp()
    {
        GameManager.SetSpeed(GameManager.speed/3);
        warriorShield.SetActive(false);
    }
}
