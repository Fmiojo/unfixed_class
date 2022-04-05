using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNextFloor : MonoBehaviour
{
    [SerializeField]
    GameObject floor;
    
    void OnTriggerEnter()
    {
        SpawnFloor();
    }
    void SpawnFloor()
    {
        Vector3 pos = new Vector3(floor.transform.position.x, floor.transform.position.y, floor.transform.position.z + floor.transform.localScale.z);
        Instantiate(floor, pos, Quaternion.identity);
    }
}
