using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubic : MonoBehaviour
{
    public Transform A, B, C, D, AB, BC, CD,
                                 ABBC, BCCD, BOULA;
    public float t;
    void Update()
    {
        t = (t + Time.deltaTime) % 1f;
        AB.position = Vector3.Lerp(A.position, B.position, t);
        BC.position = Vector3.Lerp(B.position, C.position, t);
        CD.position = Vector3.Lerp(C.position, D.position, t);
        ABBC.position = Vector3.Lerp(AB.position, BC.position, t);
        BCCD.position = Vector3.Lerp(BC.position, CD.position, t);
        BOULA.position = Vector3.Lerp(ABBC.position, BCCD.position, t);
    }
}
