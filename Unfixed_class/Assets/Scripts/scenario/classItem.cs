using System.Collections;
using UnityEngine;

public class classItem : MonoBehaviour
{
   
    public GameManager.Classes itemClass;

    void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Player"))
       {
           GameManager.ChangeClass(itemClass);
           Destroy(transform.parent.gameObject);
       }
    }
}
