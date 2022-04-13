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
            SpawnFloor();
        }
    }
    void SpawnFloor()
    {
        if(spawned == true){return;}
        Instantiate(floors[(int)GameManager.instance.CurrentEnviroment],transform.position,Quaternion.identity);
        spawned = true;
    }
}
