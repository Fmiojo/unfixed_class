using System;
using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public static ObstacleSpawner instance;
    GameObject [] targetArray;
    [SerializeField]
    public int SpawnChance
    {
        get;set;
    }
    [SerializeField]
    GameObject [] woodObjects;
    [SerializeField]
    GameObject [] stoneObjects;
    [SerializeField]
    GameObject [] metalObjects;
    [SerializeField]
    float MinTime
    {
        get;set;
    }
    [SerializeField]
    float MaxTime
    {
        get;set;
    }
    [SerializeField]
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
        SpawnChance = 60;
        MaxTime = 2f;
        MinTime = 1f;
        Invoke("SetType",0.5f);
    }

    public void SetType()
    {
        switch(GameManager.instance.CurrentEnviroment)
        {
            case GameManager.Enviroments.Forest:
            {
                targetArray = woodObjects;
                break;
            }
            case GameManager.Enviroments.City:
            {
                targetArray = stoneObjects;
                break;
            }
            case GameManager.Enviroments.Dungeon:
            {
                targetArray = metalObjects;
                break;
            }

        }
    }
    public void Spawn(GameObject targetSpawn, int tile)
    {
        Vector3 pos = new Vector3(GameManager.instance.tilesPos[tile],transform.position.y,transform.position.z);
        Instantiate(targetSpawn,pos,Quaternion.identity);
    }
    public void StartRegularSpawning()
    {
        Stop = false;
        StartCoroutine(RegularSpawning());
    }
    public void StopRegularSpawning()
    {
        Stop = true;
    }
    IEnumerator RegularSpawning()
    {
        while(Stop == false)
        {
            for(int tile = 0; tile<GameManager.instance.tilesPos.Length;tile++)
            {
                int chanceInt = UnityEngine.Random.Range(0,100);
                if(chanceInt<SpawnChance)
                {
                    GameObject target = targetArray[UnityEngine.Random.Range(0,targetArray.Length)]; 
                    Spawn(target ,tile);    
                }
            }
            float time = UnityEngine.Random.Range(MinTime,MaxTime);
            yield return new WaitForSeconds(time);   
        }
        yield break;
    }
}
