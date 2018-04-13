using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    #region Public Variables
    public Rigidbody ropeStart;
    public GameObject rope;
    public int noOfRopes;
    #endregion

    #region Private Variables
    #endregion

    #region Callbacks
    void Start()
    {
        CreateRope();
    }

    void Update()
    {

    }
    #endregion

    #region Functions
    void CreateRope()
    {
        Rigidbody previousRg = ropeStart;
        for (int i = 0; i < noOfRopes; i++)
        {
            GameObject noOfRope = Instantiate(rope, transform);
            HingeJoint joint = noOfRope.GetComponent<HingeJoint>();
            joint.connectedBody = previousRg;
            previousRg = noOfRope.GetComponent<Rigidbody>();
        }
    }
    #endregion
}
