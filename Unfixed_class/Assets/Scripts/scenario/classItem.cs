using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class classItem : MonoBehaviour
{
   
    public GameManager.Classes itemClass;
    void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Player"))
       {
           GameManager.ChangeClass(itemClass);
           Destroy(gameObject);
       }
    }
}
