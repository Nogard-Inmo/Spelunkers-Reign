using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage;
    public float speed;
    public float attackCooldown;
    public float attackTime;
    public Rigidbody2D rb;

    public Vector2 playerPos;

    public GameObject player;

    private void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        LocatePlayer();
        MoveToPlayer();
        print("Hello");
    }

    public virtual void Attack(GameObject target)
    {
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
            print("Attacking " + target.name + " for " + damage + " damage.");
            targetHealth.TakeDamage(damage);
        }
    }
    public virtual void LocatePlayer()
    {
        playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        
    }

    public virtual void MoveToPlayer()
    {
        rb.MovePosition(Vector2.MoveTowards(rb.position, playerPos, speed * Time.deltaTime));
    }
}
