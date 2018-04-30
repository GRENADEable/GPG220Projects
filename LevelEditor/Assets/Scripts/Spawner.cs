using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Public Variables
    public ZombieStats zomStats;
    #endregion

    #region Private Variables
    private GameObject[] tiles;
    private GameObject[] crowdTiles;
    #endregion

    #region Callbacks
    void Start()
    {
        tiles = GameObject.FindGameObjectsWithTag("MonsterSpawn");
        //crowdTiles = GameObject.FindGameObjectsWithTag("CrowdSpawner");

        Vector3 pos = new Vector3(0, 1f, 0);

        for (int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i] != null)
            {
                GameObject crowdObj = Instantiate(zomStats.monster, tiles[i].transform.position + pos, Quaternion.identity);
                crowdObj.transform.parent = gameObject.transform;
            }
        }
    }
    #endregion
}
