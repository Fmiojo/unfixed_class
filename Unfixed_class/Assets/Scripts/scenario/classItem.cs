using System.Collections;
using UnityEngine;

public class classItem : MonoBehaviour
{
   
    public GameManager.Classes itemClass;

    void OnTriggerEnter(Collider other)
    {
       if(other.gameObject == GameManager.instance.Player)
       {
           GameManager.instance.CurrentClass = itemClass;
           PlayerClassChange.instance.ChangeClass(GameManager.instance.CurrentClass); 
           Destroy(transform.parent.gameObject);
       }
    }
}
