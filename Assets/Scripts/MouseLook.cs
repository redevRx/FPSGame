using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public float xRotation = 0f;

    public float rotY = 0.0f; // rotation around the up/y axis
    public float rotX = 0.0f; // rotation around the right/x axis


    // Start is called before the first frame update
    void Start()
    {
        LockMosue();
    }

    // Update is called once per frame
    void Update()
    {
        MouseMove();
        //JoyLook();
    }

    private void TryMove()
    {
        rotX = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotY -= Input.GetAxis("Mouse Y") * mouseSensitivity;

     
            //RotY
            rotY = Mathf.Clamp(rotY, -90, 90);
            Camera.main.transform.localRotation = Quaternion.Euler(rotY, 0, 0);

            //RotX
            transform.Rotate(0, rotX, 0);
        //playerBody.Rotate(Vector3.up * rotX);

    }

    private void MouseLooking() {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation,0f ,0f);
        playerBody.rotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

 
    //code on video not working
    //Search Mouse Looking
    //code from https://answers.unity.com/questions/29741/mouse-look-script.html
    private void MouseMove()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -80f, 80f);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
        playerBody.Rotate(Vector3.up * mouseX * Time.deltaTime);
    }

 

  

    private void LockMosue()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }
}
