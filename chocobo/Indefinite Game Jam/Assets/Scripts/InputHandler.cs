using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputHandler : MonoBehaviour {

    //mouse
    public Vector2 Mouse_Position;
    public float Mouse_Scroll_Wheel_Value;

    public Vector3 leftJoystickDirection;
    List<KeyCode> currentKeysDown;

    void Update()
    {
        Mouse_Position = Input.mousePosition;
        Mouse_Scroll_Wheel_Value = Input.GetAxis("Mouse ScrollWheel");

        leftJoystickDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
