using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{
    // Public variables exposed to the Unity menus.
    public float maxSpeed = 5;
    public float jumpTakeOffSpeed = 10;
    public float maxNumberOfJumps = 1;
    public float jumpLiftForAdditionalJumps = 0;

    // Private variables so we have references to our components.
    private SpriteRenderer spriteRenderer;
    private bool currentFlip = false;
    private int countJumps = 0;

    // Use this for initialization
    void Awake()
    {
        // Get references to the components we need later.
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void ComputeVelocity()
    {
        // Zero our move vector to start with.
        Vector2 move = Vector2.zero;

        // Get the value from the horizontal input access of the Input Manager.
        move.x = Input.GetAxis("Horizontal");

        if (maxNumberOfJumps != 0)
        {
            // Check if the player is on the ground and if so, reset the number of jumps.
            if (countJumps >= 1 && grounded)
            {
                velocity.y = 0;
                countJumps = 0;
            }

            // Check if the Jump button has been pressed and whether we are on the floor or not.
            if (Input.GetButtonDown("Jump") && grounded)
            {
                // Set the jump speed.
                velocity.y = jumpTakeOffSpeed;
            }
            else if (Input.GetButtonUp("Jump"))
            {
                countJumps++;

                // If the jump key is pressed again, attempt an additional jump.
                if (countJumps > 1 && countJumps <= maxNumberOfJumps)
                {
                    velocity.y = jumpTakeOffSpeed + (velocity.y * 0.5f) + jumpLiftForAdditionalJumps;
                }
                // If the velocity on the y-axis is more than 0.
                else if (velocity.y > 0)
                {
                    GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

                    // Reduce the y-velocity by half.
                    velocity.y *= 0.5f;
                }
            }
        }

        // Depending on which direction we are moving, flip the sprite accordingly.
        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));

        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        // If right key is pressed
        if (Input.GetAxis("Horizontal") > 0)
        {
            currentFlip = false;
        }

        // If left key is pressed
        if (Input.GetAxis("Horizontal") < 0)
        {
            currentFlip = true;
        }

        if (move.x == 0)
        {
            spriteRenderer.flipX = currentFlip;
        }

        // Finally apply the velocity and move the character.
        targetVelocity = move * maxSpeed;
    }
}
