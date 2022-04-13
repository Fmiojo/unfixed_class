using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public static PowerUpSpawner instance;
    [SerializeField]
    GameObject [] targetArray;
    public float MinTime
    {
        get;set;
    }
    public float MaxTime
    {
        get;set;
    }
    public bool Stop
    {
        get;set;
    }

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        MinTime = 30;
        MaxTime = 60;
        StartRegularSpawning();
    }
    void Spawn(int targetIndex, int tile)
    {
        Vector3 pos = new Vector3(GameManager.instance.tilesPos[tile],transform.position.y,transform.position.z);
        GameObject target = targetArray[targetIndex];
        Instantiate(target,pos,Quaternion.identity);
    }
    void StartRegularSpawning()
    {
        Stop = false;
        StartCoroutine(RegularSpawning());
    }
    void StopRegularSpawning()
    {
        Stop = true;
    }
    IEnumerator RegularSpawning()
    {
        while(Stop == false)
        {
            float time = UnityEngine.Random.Range(MinTime,MaxTime);
            int tile =  UnityEngine.Random.Range(0,GameManager.instance.tilesPos.Length);
            int targetIndex = UnityEngine.Random.Range(0,targetArray.Length);
            Spawn(targetIndex,tile);
            yield return new WaitForSeconds(time);
        }
        yield break;
    }
}
