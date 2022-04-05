using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class playerMove : MonoBehaviour
{
    Collider playerCollider;
    Rigidbody rb;
    public enum Tiles{Left, Mid, Right}
    [SerializeField]
    Tiles playerTile;
    [SerializeField]
    public float jumpHeight;
    [SerializeField, Range(0, 1)]
    float rollingSize;
    float jumpSpeed;
    public static bool grounded = true;
    bool rolling = false;
    bool changingTile = false;
    Vector3 inicialScale;
    Vector3 finalScale;
    void Start()
    {
        playerCollider = gameObject.GetComponent<Collider>();
        rb = gameObject.GetComponent<Rigidbody>();
    }    
    void Update()
    {
        if(GameManager.paused == true)
        {
            return;
        }
        CheckGround();
        if(Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(Jump());
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine("Roll");
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(ChangeTile((int)playerTile-1));
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(ChangeTile((int)playerTile+1));
        }

    }
    void CheckGround()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, playerCollider.transform.localScale.y+0.1f))
        { 
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }
    IEnumerator Jump()
    {
        if((rolling == true)||(grounded == false))
        {
            yield break;
        }
        jumpSpeed = Mathf.Sqrt(jumpHeight * -2.0f * Physics.gravity.y);
        Vector3 jumpForce = new Vector3(0, jumpSpeed, 0);
        rb.AddForce(jumpForce, ForceMode.VelocityChange);
        yield break;
    }
    IEnumerator Roll()
    {
        if(rolling == true)
        {
            yield break;
        }
        rolling = true;
        inicialScale = transform.localScale;
        finalScale = new Vector3(inicialScale.x, inicialScale.y * rollingSize, inicialScale.z);
        rb.AddForce(Vector3.down * 10, ForceMode.VelocityChange);
        while(grounded == false)
        {
            yield return null;
        }
        float i = 0;
        while(i <= 1)
        {
            Vector3 size = Vector3.Lerp(inicialScale, finalScale, i);
            i += Time.fixedDeltaTime*3;
            transform.localScale = size;
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        i = 0;
        while(i <= 1)
        {
            Vector3 size = Vector3.Lerp(finalScale, inicialScale, i);
            i += Time.fixedDeltaTime*3;
            transform.localScale = size;
            yield return null;
        }
        rolling = false;
        yield break;
    }
    IEnumerator ChangeTile(int posIndex)
    {
        if(changingTile == true)
        {
            yield break;
        }
        changingTile = true;
        posIndex = Mathf.Clamp(posIndex,0,GameManager.tilesPos.Length-1);
        float i = 0;
        while(i<=1)
        {     
            float x = Mathf.Lerp(GameManager.tilesPos[(int)playerTile],GameManager.tilesPos[posIndex],i);
            Vector3 targetPos = new Vector3(x,transform.position.y,transform.position.z);
            transform.position = targetPos;
            i += Time.fixedDeltaTime;
            yield return null;
        }
        playerTile = (Tiles)posIndex;
        changingTile = false;
        yield break;
    }
}