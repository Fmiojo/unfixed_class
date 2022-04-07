using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : PowerUps
{
    [SerializeField]
    GameObject staff;
    public override void PowerUp()
    {
        staff.SetActive(true);
        skillReady = false;
        StartCoroutine(CoolDown(this.coolDownTime));
    }
}
