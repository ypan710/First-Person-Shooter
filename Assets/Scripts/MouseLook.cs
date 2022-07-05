using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;

    // declare variables for vertical rotation
    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    // declare a private variable for vertical angle
    private float verticalRot = 0;

    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseX) 
        {
            // horizontal rotation here
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0); 
        }
        else if (axes == RotationAxes.MouseY) 
        {
            // vertical rotation here
            verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVert; // increment the vertical angle based on the mouse
            verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert); // clamp the vertical angle between minimum and maximum limits

            float horizontalRot = transform.localEulerAngles.y; // keep the same Y angle, no horizontal rotation

            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0); // create a new vector from the stored rotation values
        }
        else 
        {   // horizontal and vertical rotation here
            verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVert; // increment the vertical angle based on the mouse
            verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert); // clamp the vertical angle between minimum and maximum limits

            float delta = Input.GetAxis("Mouse X") * sensitivityHor; // delta is the amount to change the rotation by
            float horizontalRot = transform.localEulerAngles.y + delta; // increment the rotation angle by delta

            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0); // create a new vector from the stored rotation values
        }
        
    }
}
