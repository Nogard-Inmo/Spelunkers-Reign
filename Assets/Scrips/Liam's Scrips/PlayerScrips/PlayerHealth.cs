using UnityEngine;
using System.Collections;

public class PlayerHealth : Health
{
    [SerializeField] Transform healthbarBar;
    public bool canRegen = true;

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
        StartCoroutine(NaturalHealthRegen());
    }

    public void UpdateHealthBar()
    {
        float ratio = (float)currentHealth / maxHealth;
        healthbarBar.localScale = new Vector2(ratio, healthbarBar.localScale.y);
    }
    IEnumerator NaturalHealthRegen()
    {
        while (canRegen)
        {
            yield return new WaitForSeconds(5f); // Wait for 5 seconds
            if (currentHealth < maxHealth)
            {
                currentHealth += 1; // Regenerate 1 health point
                if (currentHealth > maxHealth)
                    currentHealth = maxHealth; // Ensure health doesn't exceed max
            }
        }
    }
}
