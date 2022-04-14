using System;
using System.Collections;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public static CameraMove instance;
    [SerializeField, Range(0,1)]
    float followFactor;
    public bool PreGame
    {
        get;set;
    }
    public bool Game
    {
        get;set;
    }
    GameObject Target;
    void Awake()
    {
        instance = this;
    }
    void SetTargetRef()
    {
        Target = GameManager.instance.Player;
    }
    void FixedUpdate()
    {
        if(PreGame == true)
        {
            Orbit();
        }
        if(Game == true)
        {
            FollowWithOffset();
        }
    }
    public void PreGameSet()
    {
        instance.PreGame = true;
        instance.SetTargetRef();
    }
    public void NewGame()
    {
        instance.StartCoroutine(ChangePosition());
    }
    IEnumerator ChangePosition()
    {
        Vector3 inicialPos = transform.position;
        Vector3 finalPos = new Vector3(Target.transform.position.x,Target.transform.position.y+7,Target.transform.position.z-11);
        Quaternion inicialRot = transform.rotation;
        Quaternion finalRot = Quaternion.Euler(18,0,0);
        float t = 0;
        while(t <= 1)
        {
            t+= Time.fixedDeltaTime;
            transform.rotation = Quaternion.Lerp(inicialRot,finalRot,t);
            transform.position = Vector3.Lerp(inicialPos,finalPos,t);
            yield return null;
        }
        PreGame = false;
        Game = true;
        yield break;
    }
    void Orbit()
    {
        transform.RotateAround(Target.transform.position,Vector3.up,20*Time.fixedDeltaTime);
    }
    void FollowWithOffset()
    {
        transform.position = new Vector3(Target.transform.position.x*followFactor, transform.position.y,transform.position.z);
    }

}
