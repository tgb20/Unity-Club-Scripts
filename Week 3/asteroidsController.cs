using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidsController : MonoBehaviour {

    Rigidbody2D rigi;

    float xForce = 0;
    float yForce = 0;

    public int shipSpeed;

    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseScreenPosition - (Vector2)transform.position).normalized;
        transform.up = direction;

        xForce = Input.GetAxis("Horizontal") * shipSpeed;
        yForce = Input.GetAxis("Vertical") * shipSpeed;
    }
    void FixedUpdate()
    {
        rigi.AddForce(new Vector2(xForce, yForce));
    }
}
