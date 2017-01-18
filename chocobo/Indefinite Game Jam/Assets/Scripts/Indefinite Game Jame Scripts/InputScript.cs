using UnityEngine;
using System.Collections;

public class InputScript : MonoBehaviour {

    public int playerID;

    string Left_Horizontal_Axis;
    string Left_Vertical_Axis;
    string Right_Horizontal_Axis;
    string Right_Vertical_Axis;
    string Left_Bumper;
    string Right_Bumper;
    string Left_Trigger;
    string Right_Trigger;

    public Vector2 Left_Joystick_Direction;
    public Vector2 Right_Joystick_Direction;

    void Awake()
    {
        Left_Horizontal_Axis = "Left Joystick Horizontal P" + playerID;
        Left_Vertical_Axis = "Left Joystick Vertical P" + playerID;
        Right_Horizontal_Axis = "Right Joystick Horizontal P" + playerID;
        Right_Vertical_Axis = "Right Joystick Vertical P" + playerID;
        Left_Bumper = "Left Bumper P" + playerID;
        Right_Bumper = "Right Bumper P" + playerID;
        Left_Trigger = "Left Trigger P" + playerID;
        Right_Trigger = "Right Trigger P" + playerID;
    }

    void Update()
    {
        //reset directions
        Left_Joystick_Direction = Vector2.zero;
        Right_Joystick_Direction = Vector2.zero;

        //left joystick direction
        Left_Joystick_Direction = new Vector2(Input.GetAxis(Left_Horizontal_Axis), Input.GetAxis(Left_Vertical_Axis));

        //right joystick direction
        Right_Joystick_Direction = new Vector2(Input.GetAxis(Right_Horizontal_Axis), Input.GetAxis(Right_Vertical_Axis));
        
        //normalize directions       
        Left_Joystick_Direction.Normalize();
        Right_Joystick_Direction.Normalize();
    }
}
