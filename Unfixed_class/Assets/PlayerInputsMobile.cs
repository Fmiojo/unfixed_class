using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputsMobile : MonoBehaviour
{

    public static PlayerInputsMobile instance;
    public bool InputsOn
    {
        get;set;
    }
    Vector2 inicialTouchPos;
    Vector2 finalTouchPos;
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
        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            switch(touch.phase)
            {
                case TouchPhase.Began:
                inicialTouchPos = touch.position;
                break;

                case TouchPhase.Moved:
                finalTouchPos = touch.position;
                break;

                case TouchPhase.Ended:
                finalTouchPos = touch.position;
                break;
            }
        }
    }
    void CheckTouch()
    {
        Vector2 difference = finalTouchPos-inicialTouchPos;
        if(difference.x >=0.4f)
        {
            StartCoroutine(playerMove.instance.ChangeTile((int)playerMove.instance.playerTile+1));
        }
        else if(difference.x <= -0.4f)
        {
            StartCoroutine(playerMove.instance.ChangeTile((int)playerMove.instance.playerTile-1));
        }
        else if(difference.y >= 0.3f)
        {
            StartCoroutine(playerMove.instance.Jump());
        }
        else if(difference.y <= -0.3f)
        {
            StartCoroutine(playerMove.instance.Roll());
        }
        else
        {
            PowerUps.instance.PowerUp();
        }        
    }
}
