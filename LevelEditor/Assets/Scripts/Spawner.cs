using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Public Variables
    public GameObject monster;
    public GameObject player;
    public GameObject playerTile;
    #endregion

    #region Private Variables
    private GameObject[] tiles;
    private int randomSpawnTarget;
    #endregion

    #region Callbacks
    void Start()
    {
        tiles = GameObject.FindGameObjectsWithTag("MonsterSpawn");
        playerTile = GameObject.FindGameObjectWithTag("PlayerSpawner");
        randomSpawnTarget = Random.Range(0, tiles.Length);
        Vector3 pos = new Vector3(0, 1f, 0);

        for (int i = 0; i < tiles.Length; i++)
        {
            Instantiate(monster, tiles[i].transform.position + pos, Quaternion.identity);
        }

        Instantiate(player, playerTile.transform.position + pos, Quaternion.identity);
    }

    void Update()
    {

    }
    #endregion
}
