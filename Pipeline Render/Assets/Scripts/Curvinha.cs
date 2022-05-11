using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curvinha : MonoBehaviour
{
    
    public Transform A, B, C, AB, BC, bolinha;
    public float t;
    void Update()
    {
        t = (t + Time.deltaTime) % 1f;
        AB.position = Vector3.Lerp(A.position, B.position, t);
        BC.position = Vector3.Lerp(B.position, C.position, t);
        bolinha.position = Vector3.Lerp(AB.position, BC.position, t);
    }
}

