using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class playerMove : MonoBehaviour
{
    public static playerMove instance;
    Rigidbody rb;
    Collider playerCollider;
    [Header("Movement atributes")]
    [SerializeField, Range(0, 1)]
    float rollingSize;
    [SerializeField]
    float jumpHeight;
    [SerializeField]
    float gravityJumpStart;
    [SerializeField]
    float gravityJumpEnd;
    [SerializeField]
    float rollFallGravity;
    float jumpSpeed;
    [SerializeField]
    float changeSpeed;
    public enum Tiles{Left, Mid, Right}
    [Header("Tile Information")]
    [SerializeField]
    public Tiles playerTile;

    public static bool grounded = true;
    bool rolling = false;
    bool changingTile = false;
    Vector3 inicialScale;
    Vector3 finalScale;
    void Awake()
    {
        instance = this;
        playerCollider = gameObject.GetComponent<Collider>();
        rb = gameObject.GetComponent<Rigidbody>();
    }    
    void Update()
    {
        if(GameManager.instance.Paused == true)
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
    public bool GetGrounded()
    {
        return grounded;
    }
    IEnumerator Jump()
    {
        if((rolling == true)||(grounded == false))
        {
            yield break;
        }
        float groundY = transform.position.y;
        jumpSpeed = Mathf.Sqrt(jumpHeight * -2.0f * Physics.gravity.y);
        Vector3 jumpForce = new Vector3(0, jumpSpeed-Physics.gravity.y*(1.0f-gravityJumpStart), 0);
        rb.AddForce(jumpForce,ForceMode.VelocityChange);
        yield return new WaitUntil(()=>jumpHeight/2 <= transform.position.y-groundY);
        Vector3 midJumpForce = new Vector3(0,Physics.gravity.y*(1.0f-gravityJumpStart) , 0);
        rb.AddForce(midJumpForce,ForceMode.VelocityChange);
        yield return new WaitUntil(()=>rb.velocity.y<= 0);
        rb.AddForce(Physics.gravity*(gravityJumpEnd-1),ForceMode.VelocityChange);
        yield break;
    }
    IEnumerator Roll()
    {
        if(rolling == true)
        {
            yield break;
        }
        StopCoroutine(Jump());
        rolling = true;
        inicialScale = transform.localScale;
        finalScale = new Vector3(inicialScale.x, inicialScale.y * rollingSize, inicialScale.z);
        rb.AddForce(Vector3.down * rollFallGravity, ForceMode.VelocityChange);
        while(grounded == false)
        {
            yield return null;
        }
        float i = 0;
        do
        {
            i += Time.fixedDeltaTime*3;
            i = Mathf.Clamp(i,0,1);
            Vector3 size = Vector3.Lerp(inicialScale, finalScale, i);
            transform.localScale = size;
            yield return null;
        }while(i < 1);
        yield return new WaitForSeconds(0.5f);
        i = 0;
        do
        {
            i += Time.fixedDeltaTime*3;
            i = Mathf.Clamp(i,0,1);
            Vector3 size = Vector3.Lerp(finalScale, inicialScale, i);
            transform.localScale = size;
            yield return null;
        }while(i < 1);
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
        posIndex = Mathf.Clamp(posIndex,0,GameManager.instance.tilesPos.Length-1);
        float i = 0;
        while(i<=1)
        {     
            float x = Mathf.Lerp(GameManager.instance.tilesPos[(int)playerTile],GameManager.instance.tilesPos[posIndex],i);
            Vector3 targetPos = new Vector3(x,transform.position.y,transform.position.z);
            transform.position = targetPos;
            i += Time.fixedDeltaTime * changeSpeed;
            yield return null;
        }
        playerTile = (Tiles)posIndex;
        changingTile = false;
        yield break;
    }
    public void CorrectPos(int posIndex)
    {
        StartCoroutine(CorrectPlacement(posIndex));
    }
    IEnumerator CorrectPlacement(int posIndex)
    {
        StopCoroutine(ChangeTile(0));
        float t = 0;
        while(t <= 1)
        {
            float x = Mathf.Lerp(transform.position.x,GameManager.instance.tilesPos[posIndex],t);
            Vector3 targetPos = new Vector3(x,transform.position.y,transform.position.z);
            transform.position = targetPos;
            t+= Time.fixedDeltaTime * 5;
            yield return null;
        }
        changingTile = false;
        playerTile = (Tiles)posIndex;
        yield break;
    }
}