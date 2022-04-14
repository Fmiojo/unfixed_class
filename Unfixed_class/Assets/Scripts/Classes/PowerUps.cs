using System;
using System.Collections;
using System.Dynamic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public static PowerUps instance;
    public Rigidbody rb;
    [SerializeField]
    Material classMaterial;
    [SerializeField]
    public float coolDownTime;
    [SerializeField]
    public bool skillReady = true;
    

    void OnEnable()
    {
        instance = this;
        SetComponents();
        ReadySkill();
    }
    void SetComponents()
    {
        gameObject.GetComponent<MeshRenderer>().material = classMaterial;
        rb = gameObject.GetComponent<Rigidbody>();
    }
    public bool SkillReady{get;set;}
    public float CoolDownTime{get;set;}
    public virtual void PowerUp()
    {
        if(skillReady == false)
        {
            return;
        }
    }
    public void ReadySkill()
    {
        skillReady = true;
    }
    public virtual IEnumerator CoolDown(float coolDown)
    {
        float t = 0;
        while(t<coolDown)
        {
            t+= Time.fixedDeltaTime;
            yield return null;
        }
        ReadySkill();
        yield break;
    }
}
