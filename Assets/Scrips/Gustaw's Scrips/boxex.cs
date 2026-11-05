
using UnityEngine;

public class BoxDrop : MonoBehaviour
{
    public GameObject[] drops;
    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            DropItem();
            Destroy(gameObject);
        }
    }

    void DropItem()
    {
        if (drops.Length == 0) return;

        int randomDrop = Random.Range(0, drops.Length);

        Instantiate(
            drops[randomDrop],
            transform.position,
            Quaternion.identity
        );
    }
}
