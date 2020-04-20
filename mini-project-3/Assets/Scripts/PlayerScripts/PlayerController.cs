using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float minFallSpeed = -5.0f;
    public float maxFallSpeed = -20.0f;
    private float currentFallSpeed;
    public float strafeSpeed = 5.0f;
    public float downwardAcceleration = 5.0f;
    public float horizontalDeceleration = 130.0f;
    public float horizontalAcceleration = 2.0f;

    public Animator animator;
    public bool isSpeedingUp;

    private Vector2 velocity;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentFallSpeed = minFallSpeed;
        isSpeedingUp = false;
        print("Start");
    }


    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentFallSpeed == minFallSpeed)
            {
                currentFallSpeed = maxFallSpeed;
                isSpeedingUp = true;
                animator.SetBool("isSpeedingUp", isSpeedingUp);
                print("Speeding Up! " + isSpeedingUp);
            }
            else
            {
                currentFallSpeed = minFallSpeed;
                isSpeedingUp = false;
                animator.SetBool("isSpeedingUp", isSpeedingUp);
                print("Slowing Down! " + isSpeedingUp);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity.x--;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity.x++;
        }

        if (moveInput != 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, strafeSpeed, horizontalAcceleration * Time.deltaTime);
            velocity.y = Mathf.MoveTowards(velocity.y, currentFallSpeed, downwardAcceleration * Time.deltaTime);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, horizontalDeceleration * Time.deltaTime);
            velocity.y = Mathf.MoveTowards(velocity.y, currentFallSpeed, downwardAcceleration * Time.deltaTime);
        }

        transform.Translate(velocity * Time.deltaTime);
    }

}
