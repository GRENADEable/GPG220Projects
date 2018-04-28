using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Private Variables 
    private Rigidbody rg;
    private float inputH;
    private float inputV;
    #endregion

    #region Public Variables
    public float moveSpeed;
    public float lockRot;
    public float magnitudeToClamp;
    #endregion

    #region Unity Functions
    private void Awake()
    {
        rg = gameObject.GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        rg.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        transform.rotation = Quaternion.Euler(lockRot, transform.rotation.eulerAngles.y, lockRot);
        Vector3 vectorOfMovement = MovementInput();
        Movement(vectorOfMovement);

        if (vectorOfMovement != Vector3.zero)
        {
            transform.rotation = Turn();
        }
    }
    #endregion

    #region  My Functions
    private Vector3 MovementInput()
    {
        Vector3 playerinput;
        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");
        playerinput = new Vector3(horInput, 0, verInput).normalized;
        return playerinput;
    }

    void Movement(Vector3 movementvector)
    {
        movementvector.x = movementvector.x * moveSpeed;
        movementvector.z = movementvector.z * moveSpeed;
        movementvector.y = 0f;
        movementvector = Vector3.ClampMagnitude(movementvector, magnitudeToClamp);
        rg.AddForce(movementvector, ForceMode.Impulse);
    }

    Quaternion Turn()
    {
        Quaternion look;
        look = Quaternion.LookRotation(MovementInput());
        return look;
    }
    #endregion
}