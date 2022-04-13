using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioMoveReverse : MonoBehaviour
{
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        Vector3 move = new Vector3(0, 0, GameManager.instance.Speed);
        transform.position += move* Time.fixedDeltaTime;
    }
}
