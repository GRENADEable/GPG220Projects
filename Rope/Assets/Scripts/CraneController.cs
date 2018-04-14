using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CraneController : MonoBehaviour
{
    #region Public Variables
    public float yVel;
    #endregion

    #region Private Variables
    private Rigidbody rg;
    private Vector3 rotateVel;
    #endregion

    #region Callbacks
    void Start()
    {
        rotateVel = new Vector3(0, yVel, 0);
        rg = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Quaternion rotateRight = Quaternion.Euler(rotateVel * Time.deltaTime);
            rg.MoveRotation(rg.rotation * rotateRight);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Quaternion rotateLeft = Quaternion.Euler(-rotateVel * Time.deltaTime);
            rg.MoveRotation(rg.rotation * rotateLeft);
        }

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("RopeScene");
        }
    }
    #endregion
}