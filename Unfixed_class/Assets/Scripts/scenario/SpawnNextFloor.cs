using System;
using UnityEngine;

public class SpawnNextFloor : MonoBehaviour
{
    [SerializeField]
    GameObject [] floors;
    bool spawned = false;
    void Awake()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Trigger"))
        {
            SpawnFloor(GameManager.currentEnviroment);
        }
    }
    void SpawnFloor(GameManager.Enviroments floorEnviroment)
    {
        if(spawned == true){return;}
        Instantiate(floors[(int)floorEnviroment],transform.position,Quaternion.identity);
        spawned = true;
    }
}
