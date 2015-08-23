using UnityEngine;
using System.Collections;

public class AIChicken : MonoBehaviour {
    private EnemyMovementController movementController;
    private Vector3 target;

    private Vector3 topPosition, bottonPosition, leftPosition, rightPosition;

    [SerializeField]
    private float movementRange;

	// Use this for initialization
	void Start () {
        topPosition = GameObject.Find("TopLimit").transform.position;
        bottonPosition = GameObject.Find("BottomLimit").transform.position;
        leftPosition = GameObject.Find("LeftLimit").transform.position;
        rightPosition = GameObject.Find("RightLimit").transform.position;
        movementController = GetComponent<EnemyMovementController>();
        target = new Vector3(Random.Range(leftPosition.x, rightPosition.x),
            transform.position.y, Random.Range(bottonPosition.z, topPosition.z));
        movementController.moveTo(target);
        InvokeRepeating("selectNewTarget", 15, 10);
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position, target) <= 0.9)
            movementController.stop();
	}

    private void selectNewTarget()
    {
       // do
        //{
            target = new Vector3(Random.Range(leftPosition.x, rightPosition.x),
                transform.position.y, Random.Range(bottonPosition.z, topPosition.z));
        //} while (Vector3.Distance(target, transform.position) > movementRange);
        movementController.moveTo(target);
    }
}
