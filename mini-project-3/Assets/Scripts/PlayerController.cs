using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float minFallSpeed = -5.0f;
    public float maxFallSpeed = -20.0f;
    private float currentFallSpeed;
    public float strafeSpeed = 1.0f;
    public float downwardAcceleration = 5.0f;
    public float horizontalDeceleration = 0.5f;
    public float horizontalAcceleration = 0.2f;

    private Vector2 velocity;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentFallSpeed = minFallSpeed;
    }


    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentFallSpeed == minFallSpeed)
                currentFallSpeed = maxFallSpeed;
            else
                currentFallSpeed = minFallSpeed;
        }

        if (moveInput != 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, strafeSpeed * moveInput, horizontalAcceleration * Time.deltaTime);
            velocity.y = Mathf.MoveTowards(velocity.y, currentFallSpeed, downwardAcceleration * Time.deltaTime);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, horizontalDeceleration * Time.deltaTime);
            velocity.y = Mathf.MoveTowards(velocity.y, currentFallSpeed, downwardAcceleration * Time.deltaTime);
        }
        print("Current fall speed = " + velocity.y);
        transform.Translate(velocity * Time.deltaTime);
    }
}
