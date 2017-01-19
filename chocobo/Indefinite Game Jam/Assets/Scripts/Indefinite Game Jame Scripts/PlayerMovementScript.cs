using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour {

    InputScript InputScript;
    Rigidbody2D rb2d;
    Vector2 playerPosition;
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
        playerPosition.x = transform.position.x;
        playerPosition.y = transform.position.y;
        rb2d.MovePosition(playerPosition + InputScript.Left_Joystick_Direction * movementSpeed * Time.deltaTime);
    }
}
