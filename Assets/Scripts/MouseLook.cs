using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public Transform playerBody;

    public float clampAngle = 80.0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis
    // Start is called before the first frame update
    void Start()
    {
        LockMosue();
        SetUpRatate();
    }

    // Update is called once per frame
    void Update()
    {

        //
        MouseMove();
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

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void LockMosue()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void SetUpRatate()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }
}
