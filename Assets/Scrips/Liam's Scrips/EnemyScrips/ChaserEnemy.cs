using UnityEngine;
using UnityEngine.AI;

public class ChaserEnemy : EnemyBase
{
    [SerializeField] Collider2D attackHitbox;
    bool playerInHitBox;

    private void Update()
    {
        attackCooldown -= Time.deltaTime;

        if (attackCooldown < 0)
            attackCooldown = 0;

        LocatePlayer();
        MoveToPlayer();
        if (Vector2.Distance(transform.position, playerPos) <= attackRange && playerInHitBox)
        { 
            Attack(player);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInHitBox = true;
        }
    }
}
