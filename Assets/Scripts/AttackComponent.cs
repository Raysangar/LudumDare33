using UnityEngine;
using System.Collections;

public class AttackComponent : MonoBehaviour {

    [SerializeField]
    private float timeBetweenAttacks;

    [SerializeField]
    private float attackRange;

    private float timeSinceLastAttack;
    private Animator animator;

    void Start()
    {
        timeSinceLastAttack = timeBetweenAttacks;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        timeSinceLastAttack += Time.deltaTime;
    }

    public float getAttackRange()
    {
        return attackRange;
    }

    public void AttackTo(GameObject target)
    {
        if (timeSinceLastAttack < timeBetweenAttacks) return;
        Vector3 lookAtPosition = target.transform.position;
        lookAtPosition.y = transform.position.y;
        transform.LookAt(lookAtPosition);
        //target.SendMessage("ReceiveDamage", attackDamage);
        animator.SetTrigger("Attack");
        timeSinceLastAttack = 0;
    }
}
