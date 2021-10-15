using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10.0f;
    public Vector3 velocity;
    public CharacterController controller;
    public float jumpHeight = 3.0f;
    public float gravity = -9.81f;
    public GameObject groundCheck;
    private GroundCheck checker;
    public GameObject camera;

    void Start()
    {
        checker = groundCheck.GetComponent<GroundCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(x, 0, z);
        movement = movement.normalized * speed * Time.deltaTime;

        controller.Move(movement);

        if (checker.isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        if (velocity.y > 0)
        {
            checker.isGrounded = false;
        }

        if (Input.GetButtonDown("Jump") && checker.isGrounded) //controller.isGrounded
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        camera.transform.position = new Vector3(4, this.transform.position.y + 14, -4);
    }
}