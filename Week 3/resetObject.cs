﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetObject : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col){

		if (col.collider.tag == "Player") {
			Application.LoadLevel (Application.loadedLevelName);
		}


	}



}
