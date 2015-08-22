using UnityEngine;
using System.Collections;

public class AIComponent : MonoBehaviour {
    private GameObject altar;
    private GameObject target;
    private EnemyMovementController movementController;
    private AttackComponent attackComponent;

	void Start () {
        altar = GameObject.Find("Altar");
        target = altar;
        movementController = GetComponent<EnemyMovementController>();
        attackComponent = GetComponent<AttackComponent>();
	}
	
	void Update () {
        if (Vector3.Distance(transform.position, target.transform.position) <= attackComponent.getAttackRange())
        {
            movementController.stop();
            attackComponent.AttackTo(target);
        }
        else
            movementController.moveTo(target.transform.position);
	}

    private void PlayerDetected(GameObject player)
    {
        if (target != player && Vector3.Distance(player.transform.position, transform.position) <
            Vector3.Distance(altar.transform.position, transform.position))
        {
            target = player;
        }
    }

    private void PlayerOutOfRange(GameObject player)
    {
        if (target == player)
            target = altar;
    }
}
