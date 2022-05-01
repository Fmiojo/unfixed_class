using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : PowerUps
{
    [SerializeField]
    AudioSource magicSound;
    [SerializeField]
    GameObject staff;
    public override void PowerUp()
    {
        staff.SetActive(true);
        skillReady = false;
        StartCoroutine(CoolDown(this.coolDownTime));
        magicSound.Play();
        Invoke("EndPowerUp",1f);
    }
    public void EndPowerUp()
    {
        staff.SetActive(false);
    } 
}
