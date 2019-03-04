﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {
	
	public float speed = 6.0f;
	public float gravity = -9.8f;
	
	Vector3 startPosition;
	Quaternion startRotation;
	
	private CharacterController _charCont;
	
	
    // Start is called before the first frame update
    void Start()
    {
		startPosition = transform.position;
		startRotation = transform.rotation;
		
        _charCont = GetComponent<CharacterController> ();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;
		Vector3 movement = new Vector3 (deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude (movement, speed);
		
		movement.y = gravity;
		
		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		_charCont.Move(movement);
		
		if (transform.position.y < -1f) {
			respawn();
		}
    }
	
	void respawn() {
		this.transform.position = startPosition;
	}
}
