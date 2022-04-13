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
            skillReady = false;
            StartCoroutine(CoolDown(this.coolDownTime));
            speedParticles.SetActive(true);
            rb = gameObject.GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.AddForce(new Vector3(0, -gameObject.GetComponent<Rigidbody>().velocity.y, 0), ForceMode.VelocityChange);
            skillReady = false;
            GameManager.instance.Speed = GameManager.instance.Speed*5;
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
        GameManager.instance.Speed = GameManager.instance.Speed/5;
        while(playerMove.grounded == false)
        {
            yield return null;
        }
        jumpUsed = false;
        yield break;
    }
}
