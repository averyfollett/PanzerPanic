using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerMovement : MonoBehaviour
{
    public float acceleration;
    public float turningAcceleration;
    public float maxSpeed;
    public float maxTurningSpeed;
    public int playerId;
    public GameObject treads;

    private Rigidbody2D rb;
    private float speed;
    private float rotationSpeed;
    private int travelled;

    //variables for reinput
    private Player player;
    private CharacterController cc;
    private float forward;
    private float turn;

    private void Awake()
    {
        player = ReInput.players.GetPlayer(playerId);
        cc = GetComponent<CharacterController>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        travelled = 0;
    }

    private void Update()
    {
        speed = rb.velocity.magnitude;
        rotationSpeed = Mathf.Abs(rb.angularVelocity);

        GetInput();
        ProcessInput();
    }

    private void FixedUpdate()
    {
        if (forward >= .1f || forward <= -.1f)
        {
            travelled += 1;
        }
    }

    private void GetInput()
    {
        forward = player.GetAxis("Accelerate");
        turn = player.GetAxis("Turn");
    }

    private void ProcessInput()
    {
        if(travelled % 5 == 0 && travelled != 0)
        {
            GameObject temp = Instantiate(treads, transform.position, transform.rotation);
        }
        if (forward > 0f)
        {
            if (speed < maxSpeed)
            {
                rb.AddForce(gameObject.transform.up * acceleration);
            }
        }
        else if (forward < 0f)
        {
            if (speed < maxSpeed)
            {
                rb.AddForce(gameObject.transform.up * -acceleration);
            }
        }
        if (turn > 0)
        {
            if (rotationSpeed < maxTurningSpeed)
            {
                rb.AddTorque(-turningAcceleration);
            }
        }
        else if (turn < 0)
        {
            if (rotationSpeed < maxTurningSpeed)
            {
                rb.AddTorque(1f * turningAcceleration);
            }
        }
    }
}
