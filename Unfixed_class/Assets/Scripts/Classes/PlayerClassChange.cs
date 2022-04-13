using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClassChange : MonoBehaviour
{
    public  static PlayerClassChange instance;
    public Behaviour [] ClassesScripts;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ChangeClass(GameManager.Classes targetClass)
    {
        int classIndex = (int)targetClass;
        for(int i = 0; i<instance.ClassesScripts.Length; i++)
        {
            if(classIndex == i)
            {
                instance.ClassesScripts[i].enabled = true;
            }
            else
            {
                instance.ClassesScripts[i].enabled = false;
            }
        }
    }   
}
