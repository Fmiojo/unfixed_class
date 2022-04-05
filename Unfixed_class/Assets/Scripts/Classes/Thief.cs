using System.Collections;
using UnityEngine;

public class Thief : PowerUps
{
    Rigidbody rb;
    [SerializeField]
    float hoveringTime;
    GameObject speedParticles;
    bool jumpUsed = false;
    public override void PowerUp()
    {
        if((jumpUsed == false)&&(SkillReady == false))
        {
            return;
        }
        speedParticles.SetActive(true);
        rb = gameObject.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.AddForce(new Vector3(0, -gameObject.GetComponent<Rigidbody>().velocity.y, 0), ForceMode.VelocityChange);
        GameManager.SetSpeed(GameManager.speed*5);
        StartCoroutine(CoolDown(CoolDownTime));
        jumpUsed = true;
        StartCoroutine(EndPowerUp(hoveringTime));   
    }
    IEnumerator EndPowerUp(float hoveringDuration)
    {
        float t = hoveringDuration;
        while(t>0)
        {
            t += -Time.fixedDeltaTime;
            yield return null;
        }
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        GameManager.SetSpeed(GameManager.speed/5);
        speedParticles.SetActive(false);
        while(playerMove.grounded == false)
        {
            yield return null;
        }
        jumpUsed = false;
        yield break;
    }
}
