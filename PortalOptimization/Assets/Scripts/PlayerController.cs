using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Public Variables
    public float moveSpeed;
    public float roatationSpeed;
    public float distance;
    public float angle;
    public GameObject[] objectsInScene;
    #endregion

    #region Private Variables
    private Rigidbody rg;
    #endregion

    #region Callbacks
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        objectsInScene = GameObject.FindGameObjectsWithTag("Objects");

        for (int i = 0; i < objectsInScene.Length; i++)
        {
            objectsInScene[i].SetActive(false);
        }
    }

    void FixedUpdate()
    {
        float movement = (Input.GetAxis("Vertical") * moveSpeed) * Time.deltaTime;
        float rotation = (Input.GetAxis("Horizontal") * roatationSpeed) * Time.deltaTime;

        //Yeah the worst way to move the character :(.
        transform.Translate(0, 0, movement);
        transform.Rotate(0, rotation, 0);

        Vector3 totalDirection = Vector3.zero;

        for (int j = 0; j < objectsInScene.Length; j++)
        {
            distance = Vector3.Distance(transform.position, objectsInScene[j].transform.position);

            Vector3 direction = objectsInScene[j].transform.position - transform.position;
            totalDirection += direction;
        }

        angle = Vector3.Angle(totalDirection, transform.forward);

        if (angle < 65 && distance < 30)
        {
            for (int l = 0; l < objectsInScene.Length; l++)
            {
                objectsInScene[l].SetActive(true);
            }
        }
        else
        {
            for (int l = 0; l < objectsInScene.Length; l++)
            {
                objectsInScene[l].SetActive(false);
            }
        }
    }


    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Door" && Input.GetKeyDown(KeyCode.E))
        {
            other.gameObject.SetActive(false);
        }
    }
    #endregion

    #region My Functions

    #endregion
}
