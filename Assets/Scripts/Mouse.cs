using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public Transform playerBody,playerArms;

    private float xAxisClamp = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotY = mouseX * mouseSensitivity;
        float rotX = mouseY * mouseSensitivity;

        xAxisClamp -= rotY;

        Vector3 rotPlayerArms = playerArms.transform.rotation.eulerAngles;
        Vector3 rotPlayer = playerBody.transform.rotation.eulerAngles;

        rotPlayerArms.x -= rotY;
        rotPlayerArms.z = 0;
        rotPlayer.y += rotX;

        if (xAxisClamp > 90)
        {
            xAxisClamp = 90;
            rotPlayerArms.x = 90;
        }
        else if (xAxisClamp < -90)
        {
            xAxisClamp = -90;
            rotPlayerArms.x = 270;
        }

        playerArms.rotation = Quaternion.Euler(rotPlayerArms);
        playerBody.rotation = Quaternion.Euler(rotPlayer);

    }
}
