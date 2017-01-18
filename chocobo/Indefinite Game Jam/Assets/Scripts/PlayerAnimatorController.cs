using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAnimatorController : MonoBehaviour {

    SpriteRenderer renderer;
    Animator anim;
    InputHandler ih;

    public float animationSpeedMultiplier;

    void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        ih = GetComponent<InputHandler>();
    }

    void Update()
    {
        if(ih.leftJoystickDirection.magnitude > 0)
        {
            DetermineMovementAnimation();
            anim.speed = animationSpeedMultiplier;
        }
        else { anim.speed = 0; }
    }

    private void DetermineMovementAnimation()
    {
        //horizontal direction magnitude larger than vertical direction magnitude
        if (Mathf.Abs(ih.leftJoystickDirection.x) > Mathf.Abs(ih.leftJoystickDirection.y))
        {
            if (ih.leftJoystickDirection.x > 0)
            {
                anim.SetInteger("Direction", 3);
                renderer.flipX = true;
            }
            else { anim.SetInteger("Direction", 1); renderer.flipX = false; }
        }
        else //vertical direction magnitude larger than horizontal direction magnitude
        {
            if (ih.leftJoystickDirection.y > 0)
            {
                anim.SetInteger("Direction", 2);
            }
            else { anim.SetInteger("Direction", 0); }
        }
    }
}
