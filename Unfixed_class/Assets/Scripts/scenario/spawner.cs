using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField]
    GameObject [] Objects;
    [SerializeField]
    float inicialSpawnTime;
    float [] tilePositions;
    bool stopSpawning = false;
    void Start()
    {
        GetPositions();
        StartSpawning(1,4);
    }
    void GetPositions()
    {
        tilePositions = GameManager.tilesPos;
    }
    public  void  StartSpawning(float minTime,float maxTime)
    {
        Spawn(minTime,maxTime);
    }
    public void StopSpawning()
    {
        stopSpawning = true;
    }
    public  void Spawn(float minTime,float maxTime)
    {
        int randomIndex = Random.Range(0,tilePositions.Length);
        Vector3 vectorPos = new Vector3(tilePositions[randomIndex],transform.position.y,transform.position.z);
        randomIndex = Random.Range(0,Objects.Length);
        Instantiate(Objects[randomIndex],vectorPos,Quaternion.identity);
        if(stopSpawning == true)
        {
            stopSpawning = false;
            return;
        }
        Invoke("Spawn(minTime,maxTime)",Random.Range(minTime,maxTime));
    }
   
}
