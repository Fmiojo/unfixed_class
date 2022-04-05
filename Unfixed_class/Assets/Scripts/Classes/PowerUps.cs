using System;
using System.Collections;
using System.Dynamic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField]
    Material classMaterial;
    [SerializeField]
    float coolDownTime;
    bool skillReady = true;
    
    void OnEnable()
    {
        gameObject.GetComponent<MeshRenderer>().material = classMaterial;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PowerUp();
        }
    }
    public bool SkillReady{get;set;}
    public float CoolDownTime{get;set;}
    public virtual void PowerUp()
    {

    }
    public void ReadySkill()
    {
        skillReady = true;
    }
    public virtual IEnumerator CoolDown(float coolDown)
    {
        skillReady = false;
        float t = coolDown;
        while(t!=0)
        {
            t+= -Time.fixedDeltaTime;
            t= Mathf.Clamp(t,0,coolDown);
            yield return null;
        }
        ReadySkill();
        yield break;
    }
}
