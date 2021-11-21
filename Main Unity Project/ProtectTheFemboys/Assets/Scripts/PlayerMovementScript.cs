using System.Diagnostics;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public Transform cam;
    public float speed = 0f;
    public Rigidbody playerRB;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public float jumpForce = 5f;
    private int jumpCount = 0;
    public int maxJumps = 2;

    public Animator animator;
    public bool isRunning;
    public bool isAirborne;



    // Checks player speed to see if they are doing the zoom zoom
    public bool IsRunning(Rigidbody rb)
    {
        return playerRB.velocity.magnitude > 25f;
    }

    public bool IsAirborne(Rigidbody rb)
    {
        return playerRB.velocity.y < 0f;
    }

    // Used to update a players animation parameters
    // Saves rewriting paragraphs of code
    public void updatePlayerAnimState(Animator animator)
    {
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isAirborne", isAirborne);
    }

    public void updateAnimations(Animator animator)
    {
        if (animator.GetBool("isRunning"))
        {
            UnityEngine.Debug.Log("isRunning");
        }
    }


    //update is called every frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (Input.GetKey("left shift"))
        {speed = 35f;}
        else{speed = 20f;}
        
        if (direction.magnitude >= 0.1f)
        {
            
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            //move player
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            playerRB.MovePosition(transform.position + moveDir * speed * Time.deltaTime);
        }

        // Jumping using rigidbody
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCount <= maxJumps)
            {
                playerRB.AddForce(Vector3.up * jumpForce * 5, ForceMode.Impulse);
                jumpCount++;
            }
        }

        // On ground, reset jump count
        if (playerRB.velocity.y == 0)
        {
            jumpCount = 0;
        }

    }
    
}
