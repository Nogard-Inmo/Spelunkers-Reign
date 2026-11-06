using UnityEngine;
using System.Collections;

public class PlayerHealth : Health
{
    [SerializeField] Transform healthbarBar;
    public bool canRegen = true;

    PlayerStats playerStats;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            print("K pressed");
            TakeDamage(1);
            print("dealt Damage ig");
        }
        UpdateHealthBar();
    }
    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        maxHealth = playerStats.maxHealth;
        currentHealth = maxHealth;
        StartCoroutine(NaturalHealthRegen());
    }

    public void UpdateHealthBar()
    {
        maxHealth = playerStats.maxHealth;

        float ratio = (float)currentHealth / playerStats.maxHealth;
        healthbarBar.localScale = new Vector2(ratio, healthbarBar.localScale.y);// Update the scale of the health bar based on the current health ratio
    }
    IEnumerator NaturalHealthRegen()
    {
        while (canRegen)
        {
            yield return new WaitForSeconds(5f); // Wait for 5 seconds
            if (currentHealth < playerStats.maxHealth)
            {
                currentHealth += 1; // Regenerate 1 health point
                if (currentHealth > playerStats.maxHealth)
                    currentHealth = playerStats.maxHealth; // Ensure health doesn't exceed max
            }
        }
    }
}
