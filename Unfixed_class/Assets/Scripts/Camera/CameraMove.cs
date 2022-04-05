using System;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField, Range(0,1)]
    float followFactor;
    [SerializeField]
    GameObject player;
    void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x*followFactor, transform.position.y,transform.position.z);
    }
}
