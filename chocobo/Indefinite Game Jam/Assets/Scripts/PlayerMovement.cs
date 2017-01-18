using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    InputHandler ih;
    Rigidbody2D rb2d;
    [SerializeField]
    private float movementSpeed;
    public float MovementSpeed
    {
        get { Debug.Log("Player Movement Speed: " + movementSpeed); this.GetComponent<PlayerAnimatorController>().animationSpeedMultiplier = movementSpeed; return movementSpeed; }
        set { movementSpeed = value; }
    }

    void Awake()
    {
        ih = GetComponent<InputHandler>();
        rb2d = GetComponent<Rigidbody2D>();

        if(MovementSpeed == 0) { MovementSpeed = 1; }
    }

    void Update()
    {
        rb2d.MovePosition(transform.position + ih.leftJoystickDirection * movementSpeed * Time.deltaTime);
    }

}
