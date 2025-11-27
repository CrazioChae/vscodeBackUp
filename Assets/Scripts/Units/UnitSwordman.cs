using UnityEngine;


public class UnitSwordman : MonoBehaviour
{
    [Header("Unit Stats")]
    public string unitName = "Swordman";
    public float attackRange = 1.5f;
    public float attackDamage = 25;
    public float attackCooldown = 1.2f;

    [Header("References")]
    public LayerMask enemyLayer;
    public Transform unitVisual;

    private float lastAttackTime = -Mathf.Infinity;
    private Transform currentTarget;

    private void Update()
    {
        if (currentTarget == null || Vector2.Distance(transform.position, currentTarget.position) > attackRange)
        {
            FindTarget();
        }
        else
        {
            LookAtTarget();
            float distanceToTarget = Vector3.Distance(transform.position, currentTarget.position);
            if (distanceToTarget <= attackRange)
            {
                TryAttack();
            }
            else
            {
                currentTarget = null; // Target out of range, reset target
            }
        }
    }

    private void FindTarget()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);
        float nearestDistance = Mathf.Infinity;
        Transform nearestEnemy = null;

        foreach (var hit in hits)
        {
            float distance = Vector2.Distance(transform.position, hit.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestEnemy = hit.transform;
            }
        }

        currentTarget = nearestEnemy;
    }

    private void LookAtTarget()
    {
        if (currentTarget != null)
        {
            Vector3 direction = (currentTarget.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            unitVisual.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void TryAttack()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            if (currentTarget != null)
            {
                Debug.Log($"{unitName} attacks {currentTarget.name} for {attackDamage} damage.");
            }
            lastAttackTime = Time.time;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
