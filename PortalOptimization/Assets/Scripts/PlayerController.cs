using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Public Variables
    public float movespeed;
    public float rotateLock;
    public float clampMag;
    #endregion

    #region Private Variables
    private Rigidbody rg;
    private float inputX;
    private float intputY;
    #endregion

    #region Callbacks
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(rotateLock, transform.rotation.eulerAngles.y, rotateLock);

        Vector3 movementVector = InputPlayer();

        Movement(movementVector);

        if (movementVector != Vector3.zero)
        {
            transform.rotation = PlayerRotate();
        }
    }
    #endregion

    #region My Functions
    Vector3 InputPlayer()
    {
        Vector3 input;
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        input = new Vector3(xInput, 0, yInput).normalized;
        return input;
    }

    void Movement(Vector3 moveVector)
    {
        moveVector.x = moveVector.x * movespeed;
        moveVector.z = moveVector.z * movespeed;
        moveVector.y = 0f;
        moveVector = Vector3.ClampMagnitude(moveVector, clampMag);
        rg.AddForce(moveVector, ForceMode.Impulse);
    }

    Quaternion PlayerRotate()
    {
        Quaternion lookTowards;
        lookTowards = Quaternion.LookRotation(InputPlayer());
        return lookTowards;
    }
    #endregion
}
