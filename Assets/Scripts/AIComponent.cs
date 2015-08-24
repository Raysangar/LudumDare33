using UnityEngine;
using System.Collections;

public class AIComponent : MonoBehaviour {
    private GameObject altar;
    private GameObject target;
    private EnemyMovementController movementController;
    private AttackComponent attackComponent;

    [SerializeField]
    private LayerMask targetsLayerMask;

	void Start () {
        altar = GameObject.Find("Altar");
        target = altar;
        movementController = GetComponent<EnemyMovementController>();
        attackComponent = GetComponent<AttackComponent>();
	}
	
	void Update () {

        float distance = Vector3.Distance(transform.position, target.transform.position);
        Ray ray = new Ray(transform.position, (target.transform.position - transform.position).normalized);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, distance + 10))
        {
            if (Vector3.Distance(hit.point, transform.position) <= attackComponent.getAttackRange() && (hit.collider.gameObject.layer == 10 || hit.collider.gameObject.layer == 15))
            {
                movementController.stop();
                attackComponent.AttackTo(target);
            }
            else
                movementController.moveTo(target.transform.position);
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
