using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public Transform playerBody;

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
        MouseMove();
    }


    private void MouseMove()
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
    }

    private void LockMosue()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
