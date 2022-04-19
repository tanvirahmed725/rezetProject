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

    //Max/Min view angle for camera view
    public float maxViewAngle;
    public float minViewAngle;

    //invert option, look up when mouse goes up, or reverse
    public bool invertY;

    // Start is called before the first frame update
    void Start()
    {
        // Base how far we should be from player
        offset = target.position - transform.position;

        // Take pivot and set trans.pos to target.trans.pos
        pivot.transform.position = target.transform.position;

        // Set pivot child of player
        //pivot.transform.parent = target.transform;
        pivot.transform.parent = null;
        // Hide the mouse when scene starts up 
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    // LateUpdate happens after update
    void LateUpdate()
    {
        // Stop camera if game is paused 
        if (PauseMenu.GameIsPaused)
		{
            return;
		}

        pivot.transform.position = target.transform.position;
        // Get the x position of mouse & rotate target
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        pivot.Rotate(0, horizontal, 0);

        // Get the Y pos of mouse & rotate the pivot 

        // Get the y position of mouse & rotate target
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;

        //pivot.Rotate(-vertical, 0, 0);
        //invert option
        if (invertY)
        {
            pivot.Rotate(vertical, 0, 0);
        }
        else
        {
            pivot.Rotate(-vertical, 0, 0);
        }



        //  Limit the up/down camera rotation 
        if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
        }

        if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 360f + minViewAngle)
        {
            pivot.rotation = Quaternion.Euler(360f + maxViewAngle, 0, 0);
        }

        // Move camera based on curr rotation of target & og offset
        float desiredYAngle = pivot.eulerAngles.y;
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
