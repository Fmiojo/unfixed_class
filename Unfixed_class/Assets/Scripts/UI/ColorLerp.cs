using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorLerp : MonoBehaviour
{
    float t = 0;
    Text text;
    [SerializeField]
    Color inicialColor;
    [SerializeField]
    Color finalColor;
    void Awake()
    {
        text = gameObject.GetComponent<Text>();
    }
    void FixedUpdate()
    {
        LerpColor();
    }
    void LerpColor()
    {
        t+= Time.fixedDeltaTime;
        text.color = Color.Lerp(inicialColor,finalColor,Mathf.PingPong(t,1));
    }
}
