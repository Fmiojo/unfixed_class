using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField]
    GameObject [] Objects;
    [SerializeField]
    float spawnTimer;
    float [] tilePositions;
    void Start()
    {
        GetPositions();
        InvokeRepeating("Spawn",0,spawnTimer);
    }
    public void  StartSpawning()
    {
        InvokeRepeating("Spawn",0,spawnTimer);
    }
    void GetPositions()
    {
        tilePositions = GameManager.tilesPos;
    }
    public  void Spawn()
    {
        int randomIndex = Random.Range(0,tilePositions.Length);
        Vector3 vectorPos = new Vector3(tilePositions[randomIndex],transform.position.y,transform.position.z);
        randomIndex = Random.Range(0,Objects.Length);
        Instantiate(Objects[randomIndex],vectorPos,Quaternion.identity);
    }
    public void ChangeTimer(float newTimer)
    {
        CancelInvoke();
        spawnTimer = newTimer;
        StartSpawning();
    }
}
