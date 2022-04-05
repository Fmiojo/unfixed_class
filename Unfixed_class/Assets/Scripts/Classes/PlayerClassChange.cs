using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClassChange : MonoBehaviour
{
    public Behaviour [] ClassesScripts;
    public enum Classes{Base ,Warrior, Thief}
    [SerializeField]
    public Classes playerClass;
    public void ChangeClass(Classes targetClass)
    {
        int classIndex = (int)targetClass;
        for(int i = 0; i<ClassesScripts.Length; i++)
        {
            if(classIndex == i)
            {
                ClassesScripts[i].enabled = true;
            }
            else
            {
                ClassesScripts[i].enabled = false;
            }
        }
    }   
}
