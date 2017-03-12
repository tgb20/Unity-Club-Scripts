using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerDefenceController : MonoBehaviour {

    public bool followMouse;
    public Transform target;

	
	// Update is called once per frame
	void Update () {
        if (followMouse)
        {
            Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mouseScreenPosition - (Vector2)transform.position).normalized;
            transform.up = direction;
        }else
        {
            transform.up = target.position - transform.position;
        }
	}
}
