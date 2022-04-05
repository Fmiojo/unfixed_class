using System;
using UnityEngine;

public class SpawnNextFloor : MonoBehaviour
{
    [SerializeField]
    GameObject [] floors;
    bool spawned = false;
    void Awake()
    {
        int n = UnityEngine.Random.Range(0,100);
        if(n>=70)
        {
            GameManager.ChangeEnviroment();
        }
    }
    
    void OnTriggerEnter()
    {
        SpawnFloor(GameManager.currentEnviroment);
    }
    void SpawnFloor(GameManager.Enviroments floorEnviroment)
    {
        if(spawned == true){return;}
        Instantiate(floors[(int)floorEnviroment],transform.position,Quaternion.identity);
        spawned = true;
    }
}
