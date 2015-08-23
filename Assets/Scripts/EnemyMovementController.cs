﻿using UnityEngine;
using System.Collections;

public class EnemyMovementController : MonoBehaviour {
    private Vector3 movement;
    private CharacterController characterController;

    [SerializeField]
    private float gravity;

    [SerializeField]
    private float movementSpeed;

	// Use this for initialization
	void Start () {
        characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 movementIncrement = movement * movementSpeed * Time.deltaTime;
        movementIncrement.y = -gravity * Time.deltaTime;
        characterController.Move(movementIncrement);
	}

    public void moveTo(Vector3 position)
    {
        movement = (position - transform.position).normalized;
    }

    public void setMovement(Vector3 movement)
    {
        this.movement = movement;
    }

    public void stop()
    {
        movement = Vector3.zero;
    }
}