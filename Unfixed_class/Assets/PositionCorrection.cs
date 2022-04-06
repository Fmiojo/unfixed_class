using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCorrection : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            CorrectPos();
        }
        
    }
    void CorrectPos()
    {
        Vector3 move = new Vector3(0,transform.localScale.y,0);
        transform.position += move;
    }
}
