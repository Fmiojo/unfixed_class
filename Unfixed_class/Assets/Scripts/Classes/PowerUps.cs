using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField]
    Material classMaterial;
    
    void OnEnable()
    {
        gameObject.GetComponent<MeshRenderer>().material = classMaterial;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PowerUp();
        }
    }
    public virtual void PowerUp()
    {

    }
}
