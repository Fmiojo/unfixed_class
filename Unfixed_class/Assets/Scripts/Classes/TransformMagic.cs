using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class TransformMagic : MonoBehaviour
{
    //GameObject ParticleEffect;
    bool used = false;
    void  Awake()
    {
        used = false;
        Destroy(gameObject,4);
    }
    void  OnCollisionEnter(Collision other)
    {
        if(used == true)
        {
            return;
        }
        if(other.gameObject.CompareTag("Obstacle"))
        {
            used = true;
            if(other.transform.parent == null)
            {
                Debug.Log("Parent");
                Destroy(Transform(other.gameObject));
            }
            else
            {
                Debug.Log("Child");
                Destroy(Transform(other.transform.parent.gameObject));
            }
            Destroy(gameObject);
        }
    }
    GameObject Transform(GameObject target)
    {
        Vector3 pos = target.transform.position;
        GameObject substitute = SortSubstitute();
        if(target != substitute)
            {
                Instantiate(substitute,pos,Quaternion.identity);
            }
        return target;
    }
    GameObject SortSubstitute()
    {
        GameObject substitute = ObstacleSpawner.instance.targetArray[Random.Range(0,ObstacleSpawner.instance.targetArray.Length)];
        return substitute;
    }
}
