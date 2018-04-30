using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleMonsterAI : MonoBehaviour
{
    #region Public Variables
    /*public float chaseDistance;
    public float attackDistance;*/
    public float distanceToPlayer;
    public ZombieStats zombieStats;
    [Header("Forces")]
    /*public int maxSpeed;
    public int maxForce;*/
    #endregion

    #region Private Variables
    private Rigidbody rg;
    private GameObject player;
    #endregion

    #region  Callbacks
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rg = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer < zombieStats.chaseDistance)
        {
            Vector3 desiredVel = (player.transform.position - transform.position).normalized * zombieStats.maxSpeed;
            Vector3 steering = desiredVel - rg.velocity;
            Vector3 steeringClamped = Vector3.ClampMagnitude(steering, zombieStats.maxForce);
            rg.AddForce(steeringClamped);

            Vector3 target = player.transform.position + rg.velocity;
            target.y = transform.position.y;
            transform.LookAt(target);
        }

        if (distanceToPlayer < zombieStats.attackDistance)
        {
            SceneManager.LoadScene("Level");
        }
    }
    #endregion
}
