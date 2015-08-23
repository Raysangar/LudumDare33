using UnityEngine;
using System.Collections;

public class AIChicken : MonoBehaviour {
    private EnemyMovementController movementController;
    private Vector3 target;

    [SerializeField]
    private float levelMaxWith, levelMaxLong;

	// Use this for initialization
	void Start () {
        movementController = GetComponent<EnemyMovementController>();
        InvokeRepeating("selectNewTarget", 0, 10);
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position, target) <= 0.9)
            movementController.stop();
	}

    private void selectNewTarget()
    {
        target = new Vector3(Random.Range(-levelMaxLong/2, levelMaxWith/2), transform.position.y, Random.Range(-levelMaxLong/2, levelMaxLong/2));
        movementController.moveTo(target);
    }
}
