using System.Collections;
using UnityEngine;

public class bifurcationspawn : MonoBehaviour
{
    public int iLeft
    {
        get;set;
    }
    public int iRight
    {
        get;set;
    }
    [SerializeField]
    GameObject [] floor;
    public static bifurcationspawn instance;
    void Awake()
    {
        instance = this;
        SpawnPaths();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == GameManager.instance.Player)
        {
            
        }
    }
    void SpawnPaths()
    {
        iLeft = UnityEngine.Random.Range(0,floor.Length);
        GameObject targetLeft = floor[iLeft];
        Vector3 posLeft = new Vector3(transform.position.x-(transform.localScale.x/2)-(targetLeft.transform.localScale.z/2),transform.position.y,transform.position.z);
        Instantiate(targetLeft,posLeft,Quaternion.Euler(0,-90,0));
        iRight = UnityEngine.Random.Range(0,floor.Length);
        GameObject targetRight = floor[iRight];
        Vector3 posRight = new Vector3(transform.position.x+(transform.localScale.x/2)+(targetRight.transform.localScale.z/2),transform.position.y,transform.position.z);
        Instantiate(targetRight,posRight,Quaternion.Euler(0,90,0));
    }
}
