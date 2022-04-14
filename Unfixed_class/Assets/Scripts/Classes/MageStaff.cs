using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageStaff : MonoBehaviour
{
    [SerializeField]
    GameObject magicShot;
    void OnEnable()
    {
        Magic();
    }
    void Magic()
    {
        Instantiate(magicShot,transform.position, transform.rotation);
    }
}
