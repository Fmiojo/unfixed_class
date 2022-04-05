using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenarioMove : MonoBehaviour
{
    
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        Vector3 move = new Vector3(0, 0, -GameManager.speed);
        transform.position += move* Time.fixedDeltaTime;
    }
}
