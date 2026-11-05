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

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            print(other.gameObject.name + " is in the hitbox");
            playerInHitBox = true;
        }
    }

    public override void Attack(GameObject target)
    {
        if(playerInHitBox && attackCooldown <= 0)
        {
            attackCooldown = attackTime;
            base.Attack(target);
        }
        else
        {
            Debug.Log("Player not in hitbox or attack on cooldown");
        }
    }
}
