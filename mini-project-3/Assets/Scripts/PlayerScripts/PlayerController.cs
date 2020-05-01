using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Establish downward momentum variables
    private float currentFallSpeed;
    public float minFallSpeed = -5.0f;
    public float maxFallSpeed = -20.0f;
    public float downwardAcceleration = 5.0f;

    //Establish horizontal movement variables
    public float sensitivity = 30;
    public float smooth = 0.4f;
    private Vector3 currentAcceleration, initialAcceleration;

    public bool isSpeedingUp;

    //Establish overall player movement variables
    private Vector2 velocity;
    private CharacterController controller;

    public Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentFallSpeed = minFallSpeed;
        isSpeedingUp = false;

        initialAcceleration = Input.acceleration;
        currentAcceleration = Vector3.zero;

        transform.Translate(0, 0, 0);
    }


    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        //Detect tap to change fall speed
        if (Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                changeSpeed(isSpeedingUp);
            }
        }

        //Set x and y velocities
        currentAcceleration = Vector3.Lerp(currentAcceleration, Input.acceleration - initialAcceleration, Time.deltaTime/smooth);

        velocity.x = Mathf.Clamp(currentAcceleration.x * sensitivity, -100, 100);
        velocity.y = Mathf.MoveTowards(velocity.y, currentFallSpeed, downwardAcceleration * Time.deltaTime);

        //Move the player
        transform.Translate(velocity * Time.deltaTime);
    }

    public void changeSpeed(bool speedUp)
    {
        if (speedUp == false)
        {
            currentFallSpeed = maxFallSpeed;
            isSpeedingUp = true;
            animator.SetBool("isSpeedingUp", isSpeedingUp);
        }
        else
        {
            currentFallSpeed = minFallSpeed;
            isSpeedingUp = false;
            animator.SetBool("isSpeedingUp", isSpeedingUp);
        }
    }

}
