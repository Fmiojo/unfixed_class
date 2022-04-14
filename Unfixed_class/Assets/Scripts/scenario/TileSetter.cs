using System.Collections;
using UnityEngine;

public class TileSetter : MonoBehaviour
{
    [SerializeField]
    int tiles;
    void Start()
    {
        GameManager.instance.Floor = this.gameObject;
        GameManager.instance.GetTilePos(tiles);
    }
}
