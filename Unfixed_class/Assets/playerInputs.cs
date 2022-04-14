using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class playerInputs : MonoBehaviour
{
    public static playerInputs instance;
    public bool InputsOn
    {
        get;set;
    }
    void Awake()
    {
        instance = this;
        InputsOn = false;
    }
    void Update()
    {
        if(InputsOn == false)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameManager.instance.Paused == false)
            {
                GameManager.instance.Pause();
            }
            else
            {
                GameManager.instance.Unpause();
            }
        }
        if(GameManager.instance.Paused == true)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(playerMove.instance.Jump());
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(playerMove.instance.Roll());
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(playerMove.instance.ChangeTile((int)playerMove.instance.playerTile-1));
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(playerMove.instance.ChangeTile((int)playerMove.instance.playerTile+1));
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {  
            PowerUps.instance.PowerUp();
        }
    }
}
