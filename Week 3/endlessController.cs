using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endlessController : MonoBehaviour {

    bool jump = false;

    public float moveForce = 365f;
    public float playerSpeed = 2f;
    public float maxSpeed = 5f;
    public float jumpForce = 500f;
    public Transform groundCheck;

    bool grounded = false;
    Rigidbody2D rigi;

    // Use this for initialization
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        float h = playerSpeed;

        if (h * rigi.velocity.x < maxSpeed)
            rigi.AddForce(Vector2.right * h * moveForce);
        if (jump)
        {
            rigi.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }
}
