using UnityEngine;

public class Pickups : MonoBehaviour
{
    public GameObject player;

    public PlayerHealth health;
    public BadgesUpgrades badges;
    public GameObject pickup;

    public bool isHealth;
    public bool isScrew;
    public bool isBadge;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHealth)
        {
            health = player.GetComponent<PlayerHealth>();
            health.currentHealth += 40;
        }
        else if(isScrew)
        {
            Destroy(pickup);
            return;
        }
        else if (isBadge)
        {
            badges=player.GetComponent<BadgesUpgrades>();
            badges.ActivateBadge(Random.Range(0,3));
        }
        Destroy(pickup);
        
    }

}
