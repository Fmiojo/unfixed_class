using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class classItem : MonoBehaviour
{
   
    public PlayerClassChange.Classes itemClass;
    void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerClassChange>().ChangeClass(itemClass);
        Destroy(gameObject);
    }
}
