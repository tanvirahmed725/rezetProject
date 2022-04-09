using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    // Create reference to the player ("What is target of camera?")
    public Transform target;

    // How far away we should be from player and follow
    public Vector3 offset;

    // How fast we want to rotate cam
    public float rotateSpeed;

    // Ref to pivot point
    public Transform pivot;

    // Start is called before the first frame update
    void Start()
    {
        // Base how far we should be from player
        offset = target.position - transform.position;

        // Take pivot and set trans.pos to target.trans.pos
        pivot.transform.position = target.transform.position;

        // Set pivot child of player
        pivot.transform.parent = target.transform;

        // Hide the mouse when scene starts up 
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    // LateUpdate happens after update
    void LateUpdate()
    {
        // Get the x position of mouse & rotate target
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.Rotate(0, horizontal, 0);

        // Get the Y pos of mouse & rotate the pivot 

        // Get the y position of mouse & rotate target
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        pivot.Rotate(-vertical, 0, 0);

        // Move camera based on curr rotation of target & og offset
        float desiredYAngle = target.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = target.position - (rotation * offset);

        // transform.position = target.position - offset;

        // Stop camera position below player
        if(transform.position.y < target.position.y)
		{
            transform.position = new Vector3(transform.position.x, target.position.y - 0.5f,
                transform.position.z);
		}

        transform.LookAt(target);
    }
}
