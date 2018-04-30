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
        crowdTiles = GameObject.FindGameObjectsWithTag("CrowdSpawner");

        Vector3 pos = new Vector3(0, 1f, 0);

        for (int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i] != null)
            {
                GameObject monsterObj = Instantiate(zomStats.monster, tiles[i].transform.position + pos, Quaternion.identity);
                monsterObj.transform.parent = gameObject.transform;
            }
        }

        for (int i = 0; i < crowdTiles.Length; i++)
        {
            if (crowdTiles[i] != null)
            {
                GameObject zombieObj = Instantiate(zomStats.zombie, crowdTiles[i].transform.position + pos, Quaternion.identity);
            }
        }
    }
    #endregion
}
