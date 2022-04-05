using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : PowerUps
{
    Rigidbody rb;
    [SerializeField]
    GameObject speedParticles;
    bool available = false;
    [SerializeField]
    float cooldown;
    float time;
    public override void PowerUp()
    {
        if(available == false)
        {
            return;
        }
        available = false;
        speedParticles.SetActive(true);
        rb = gameObject.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.AddForce(new Vector3(0, -gameObject.GetComponent<Rigidbody>().velocity.y, 0), ForceMode.VelocityChange);
        GameManager.SetSpeed(GameManager.speed*5);
        Invoke("EndPowerUp",0.5f);   
    }
    void EndPowerUp()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        GameManager.SetSpeed(GameManager.speed/5);
        speedParticles.SetActive(false);
    }
    void FixedUpdate()
    {
        if(playerMove.grounded == true && time <= 0)
        {
            available = true;
        }
        else
        {
            time += -Time.fixedDeltaTime;
        }
    }
}
