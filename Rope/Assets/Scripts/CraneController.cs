using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneController : MonoBehaviour
{
    #region Public Variables
    public float yVel;
    #endregion

    #region Private Variables
    private Rigidbody rg;
    private Vector3 vel;
    #endregion

    #region Callbacks
    void Start()
    {
        vel = new Vector3(0, yVel, 0);
        rg = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Quaternion rotate = Quaternion.Euler(vel * Time.deltaTime);
            rg.MoveRotation(rg.rotation * rotate);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Quaternion rotate = Quaternion.Euler(-vel * Time.deltaTime);
            rg.MoveRotation(rg.rotation * rotate);
        }
    }
    #endregion

    #region Functions

    #endregion
}
