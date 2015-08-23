using UnityEngine;
using System.Collections;

public class EnemyMovementController : MonoBehaviour {
    private Vector3 movement;
    private CharacterController characterController;
    private bool blocked;
	private Animator myAnimator;

	public float rotationDamping = 20f;

    [SerializeField]
    private float gravity;

    [SerializeField]
    private float movementSpeed;

	// Use this for initialization
	void Start () {
        blocked = false;
        characterController = GetComponent<CharacterController>();
		myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (blocked) return;
        Vector3 movementIncrement = movement * movementSpeed * Time.deltaTime;
        movementIncrement.y = -gravity * Time.deltaTime;
        characterController.Move(movementIncrement);

		if (movement != Vector3.zero)
			transform.rotation = Quaternion.Slerp(transform.rotation, 
			                                      Quaternion.LookRotation(movement), 
			                                      Time.deltaTime * rotationDamping);
		float speed = this.characterController.velocity.magnitude;
		myAnimator.SetFloat("MoveSpeed",speed);

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

    public void stopPermanently()
    {
        blocked = true;
    }
}
