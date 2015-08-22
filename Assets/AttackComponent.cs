using UnityEngine;
using System.Collections;

public class AttackComponent : MonoBehaviour {
    [SerializeField]
    private int attackDamage;

    [SerializeField]
    private float attackRange;

    public float getAttackRange()
    {
        return attackRange;
    }

    public void AttackTo(GameObject target)
    {
        Vector3 lookAtPosition = target.transform.position;
        lookAtPosition.y = transform.position.y;
        transform.LookAt(lookAtPosition);
        Debug.Log("Attacking to " + target.name);
    }
}
