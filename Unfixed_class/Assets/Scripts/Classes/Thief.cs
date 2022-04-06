using System.Collections;
using UnityEngine;

public class Thief : PowerUps
{
    [SerializeField]
    float hoveringTime;
    [SerializeField]
    GameObject speedParticles;
    [SerializeField]
    bool jumpUsed = false;
    public override void PowerUp()
    {
        if((skillReady == false)||(jumpUsed == true))
        {
            return;
        }
        else
        {
            GameManager.Setcoroutines(false);
            skillReady = false;
            StartCoroutine(CoolDown(this.coolDownTime));
            speedParticles.SetActive(true);
            rb = gameObject.GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.AddForce(new Vector3(0, -gameObject.GetComponent<Rigidbody>().velocity.y, 0), ForceMode.VelocityChange);
            skillReady = false;
            GameManager.SetSpeed(GameManager.speed*5);
            jumpUsed = true;
            StartCoroutine(EndPowerUp(hoveringTime));
        }   
    }
    IEnumerator EndPowerUp(float hoveringDuration)
    {
        float t = 0;
        while(t<hoveringDuration)
        {
            t += Time.fixedDeltaTime;
            yield return null;
        }
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        GameManager.SetSpeed(GameManager.speed/5);
        GameManager.Setcoroutines(true);
        while(playerMove.grounded == false)
        {
            yield return null;
        }
        jumpUsed = false;
        yield break;
    }
}
