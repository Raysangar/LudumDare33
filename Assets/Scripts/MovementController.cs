using UnityEngine;
using System.Collections;
//
[RequireComponent(typeof (Rigidbody))]
[RequireComponent(typeof (CharacterController))]
                  
public class MovementController : MonoBehaviour {
	
	public float rotationDamping = 20f;
	public float runSpeed = 10f;
	public int gravity = 20;
	public float jumpSpeed = 23;
	bool canJump;
	float moveSpeed;
	float verticalVel;  // Used for continuing momentum while in air    
	CharacterController controller;
	Animator anim;

	void Start()
	{
		controller = (CharacterController)GetComponent(typeof(CharacterController));
		anim = GetComponent<Animator> ();
	}

	void Update()
	{
		Attack ();
		Locomotion ();
	}

	void Attack ()
	{
		if (Input.GetKeyDown (KeyCode.E)) {
			anim.SetTrigger ("Attack");
		}
	}

	private void Locomotion ()
	{
		// Check for jump
		if (controller.isGrounded) {
			Jump ();
		}
		else {
			// Apply gravity to our velocity to diminish it over time
			verticalVel += Physics.gravity.y * Time.deltaTime;
		}
		// Actually move the character
		Move ();
	}

	private void Jump ()
	{
		canJump = true;
		if (canJump && Input.GetKeyDown ("space")) {
			// Apply the current movement to launch velocity
			verticalVel = jumpSpeed;
			canJump = false;
		}
	}

	private void Move ()
	{
		moveSpeed = UpdateMovement ();
		anim.SetFloat ("MoveSpeed", moveSpeed);
		if (controller.isGrounded)
			verticalVel = 0f;// Remove any persistent velocity after landing
	}

	private float UpdateMovement()
	{
		// Movement
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		Vector3 inputVec = new Vector3(x, 0, z);
		inputVec *= runSpeed;
		controller.Move((inputVec + Vector3.up * -gravity + new Vector3(0, verticalVel, 0)) * Time.deltaTime);
		// Rotation
		if (inputVec != Vector3.zero)
			transform.rotation = Quaternion.Slerp(transform.rotation, 
			                                      Quaternion.LookRotation(inputVec), 
			                                      Time.deltaTime * rotationDamping);
		return inputVec.magnitude;
	}

}
