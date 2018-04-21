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
    public float drawDistance;
    #endregion

    #region Private Variables
    private GameObject[] objectsInScene;
    private GameObject[] objectsInRoom;
    private GameObject camObj;
    private Camera cam;
    #endregion

    #region Callbacks
    void Start()
    {
        objectsInScene = GameObject.FindGameObjectsWithTag("Objects");
        objectsInRoom = GameObject.FindGameObjectsWithTag("ObjectsInRoom");
        camObj = GameObject.FindGameObjectWithTag("MainCamera");
        cam = camObj.GetComponent<Camera>();


        for (int h = 0; h < objectsInRoom.Length; h++)
        {
            objectsInRoom[h].SetActive(false);
        }

        for (int i = 0; i < objectsInScene.Length; i++)
        {
            objectsInScene[i].SetActive(false);
        }
    }

    void FixedUpdate()
    {
        float movement = (Input.GetAxis("Vertical") * moveSpeed) * Time.deltaTime;
        float rotation = (Input.GetAxis("Horizontal") * roatationSpeed) * Time.deltaTime;
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0)
        {
            cam.farClipPlane += drawDistance;
        }
        if (scroll < 0)
        {
            cam.farClipPlane -= drawDistance;
        }


        //Yeah the worst way to move the character :(. I wanted to get over this so yeah.
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

        if (angle < 60 && distance < 40)
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

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Door")
        {
            for (int m = 0; m < objectsInRoom.Length; m++)
            {
                objectsInRoom[m].SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Door")
        {
            for (int n = 0; n < objectsInRoom.Length; n++)
            {
                objectsInRoom[n].SetActive(false);
            }
        }
    }
    #endregion
}
