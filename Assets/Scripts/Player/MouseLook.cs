using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public Transform playerBody;
    private float xRotation = 0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    private bool isLock;
    //github code style
    private Vector2 current_Mouse_Look;
    private Vector2 look_Angles;
    private Vector2 default_Look_Limits = new Vector2(-70f, 80f);

    // Start is called before the first frame update
    void Start()
    {
        LockMosue();
    }

    // Update is called once per frame
    void Update()
    {
        CheckMouseLock();
        LookAround();
        //JoyLook();
    }


    private void CheckMouseLock()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isLock)
            {
                Cursor.lockState = CursorLockMode.None;
                isLock = !isLock;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                isLock = !isLock;
            }
        }
    }

    //working code
   private void LookAround()
    {

        current_Mouse_Look = new Vector2(
            Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));

        look_Angles.x += current_Mouse_Look.x * mouseSensitivity * (true ? 1f : -1f);
        look_Angles.y += current_Mouse_Look.y * mouseSensitivity;

        look_Angles.x = Mathf.Clamp(look_Angles.x, default_Look_Limits.x, default_Look_Limits.y);

        //current_Roll_Angle =
        //Mathf.Lerp(current_Roll_Angle, Input.GetAxisRaw(MouseAxis.MOUSE_X)
        //* roll_Angle, Time.deltaTime * roll_Speed);

        //transform.rotation = Quaternion.Euler(look_Angles.x, 0f, 0f);
        playerBody.localRotation = Quaternion.Euler(0f, look_Angles.y, 0f);


    } // look around

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
        isLock = true;
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }
}
