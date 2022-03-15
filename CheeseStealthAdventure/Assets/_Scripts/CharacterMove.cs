using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private float speed = 10f;
    private CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    bool isGrounded;
    Vector3 velocity;
    float gravity = -10f;
    float jumpStrength = 5f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isGrounded);

        RaycastHit hit;
        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, out hit, 0.2f, groundMask);
        velocity.y += gravity * Time.deltaTime;

        if (isGrounded)
        {
            velocity.y = 0;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("the space is pressed");
                velocity.y = jumpStrength;
            }
        }

        controller.Move(velocity * speed * Time.deltaTime);

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;
        controller.Move(move * speed * Time.deltaTime);
        //transform.localPosition += move/40;

    }
}
