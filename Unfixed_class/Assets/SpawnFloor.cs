using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFloor : MonoBehaviour
{
    public static SpawnFloor instance;
    [SerializeField]
    GameObject[] floors;
    void Awake()
    {
        instance = this;
    }
    public void Spawn()
    {
        GameObject target = floors[(int)GameManager.instance.CurrentEnviroment];
        Vector3 pos = new Vector3(transform.position.x, transform.position.y,transform.position.z+transform.localScale.z/2 + target.transform.localScale.z/2);
        Instantiate(target,pos, Quaternion.identity);
    }
}
