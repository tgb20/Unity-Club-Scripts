using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformerController : MonoBehaviour {

    bool facingRight = true;
    bool jump = false;

    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 0.01f;
    public Transform groundCheck;

    bool grounded = false;
    Rigidbody2D rigi;

    // Use this for initialization
    void Start () {
        rigi = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if(Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        if (h * rigi.velocity.x < maxSpeed)
            rigi.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rigi.velocity.x) > maxSpeed)
            rigi.velocity = new Vector2(Mathf.Sign(rigi.velocity.x) * maxSpeed, rigi.velocity.y);

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        if (jump)
        {
            rigi.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }

}
