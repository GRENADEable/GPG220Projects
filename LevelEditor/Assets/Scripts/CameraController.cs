using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Public Variables
    public GameObject ply;
    public Vector3 camOffset;
    #endregion

    #region Callbacks
    void Start()
    {
        ply = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.position = ply.transform.position + camOffset;
    }
    #endregion
}
