
using UnityEngine;

public class BoxDrop : Health
{
    public GameObject[] drops;

   public override void Die()
    {
        DropItem();
        base.Die();
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
