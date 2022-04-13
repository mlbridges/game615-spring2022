using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMoveAnims : MonoBehaviour
{
    //this is based heavily on the Third Person Movement Brackeys video
    //public variables for character controller and camera
    public CharacterController controller;
    public Transform cam;

    public Animator anim;

    //speed of movement
    public float speed = 6f;

    //values used for smoothing the rotation of the character and camera
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    //jump stuff
    public float gravity = -9.81f;
    public float jumpHeight = 3;
    private Vector3 velocity;
    private bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    // Update is called once per frame
    void Update()
    {
        ChickenWalk();

        ChickenEat();

        ChickenJump();
    }

    public void ChickenWalk() 
    {
        //getting the movement input from the WASD or Arrow Keys in the horizontal and vertical directions
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //putting those inputs into a normalized vector for the character to travel along
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        //if the magnitude along that vector is significant
        if (direction.magnitude >= 0.1f)
        {
            //move the character
            anim.SetBool("Walk", true);
            anim.SetBool("Idle", false);
            //calculating the angle of the movement and attaching it to the direction the camera is pointing
            //(I don't fully understand the math here, but I am trying)
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //smoothing the angle of rotation for the character
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //calculating the direction to move the character
            Vector3 MoveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //injecting that movement into the character (and normalizing it and making it update by frame so it looks smooth)
            controller.Move(MoveDir.normalized * speed * Time.deltaTime);
        }
        else 
        {
            anim.SetBool("Idle", true);
            anim.SetBool("Walk", false);
        }
    }

    public void ChickenJump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) 
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            anim.SetBool("Jump", true);
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        else 
        {
            anim.SetBool("Jump", false);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void ChickenEat() 
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            //anim.SetBool("Idle", false);
            anim.SetBool("Eat", true);
        }
        else 
        {
            //anim.SetBool("Idle", true);
            anim.SetBool("Eat", false);
        }
    }
}
