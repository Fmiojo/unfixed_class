using System.Collections;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField]
    GameObject [] Objects;
    [SerializeField]
    float inicialMinTime;
    [SerializeField]
    float inicialMaxTime;
    float [] tilePositions;
    void Start()
    {
        GetPositions();
        StartSpawning(inicialMinTime,inicialMaxTime);
    }
    void GetPositions()
    {
        tilePositions = GameManager.tilesPos;
    }
    public  void  StartSpawning(float minTime,float maxTime)
    {
        StartCoroutine(Spawn(minTime,maxTime));
    }
    public void StopSpawning()
    {
        StopAllCoroutines();
    }
    public void ChangeTimes(float minTime, float maxTime)
    {
        StopAllCoroutines();
        StartSpawning(minTime,maxTime);
    }

    IEnumerator Spawn(float minTime,float maxTime)
    {
        int randomIndex = Random.Range(0,tilePositions.Length);
        Vector3 vectorPos = new Vector3(tilePositions[randomIndex],transform.position.y,transform.position.z);
        randomIndex = Random.Range(0,Objects.Length);
        Instantiate(Objects[randomIndex],vectorPos,Quaternion.identity);
        float time = UnityEngine.Random.Range(minTime,maxTime);
        yield return new WaitForSeconds(time);
        StartSpawning(minTime,maxTime);
        yield break;
    }
   
}
