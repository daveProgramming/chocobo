using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour {

    InputScript InputScript;
    Rigidbody2D rb2d;

    private float movementSpeed;
    public float MovementSpeed
    {
        get { this.GetComponent<PlayerAnimatorController>().animationSpeedMultiplier = movementSpeed; return movementSpeed; }
        set { movementSpeed = value; }
    }

    void Awake()
    {
        InputScript = GetComponent<InputScript>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb2d.MovePosition(transform.position + InputScript.Left_Joystick_Direction * movementSpeed * Time.deltaTime);
    }
}
