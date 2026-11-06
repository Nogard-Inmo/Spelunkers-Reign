using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Badges
{
    public string badgeName;
    public string tooltip;
    public TMP_Text tooltipBox;
    public Image badgeImage;

    public float ammoMultiplier = 1f;
    public float reloadSpeed = 1f;
    public float regenAmountMultiplier = 1f;
    public float maxHealthMultiplier = 1.0f;
    public float damageMultiplier = 1.0f;
    public int amountOfBadges = 0;
    public int amountOfBadgesEquipped = 0;
    // add more multiplier if we want more different types of badges buffs
}

public class BadgesUpgrades : MonoBehaviour
{
    public Badges[] badges;
    public int badgeSlots = 3; // Number of badge slots available for the player

    public void ActivateBadge(int badgeIndex)
    {
        if (badgeIndex < 0 || badgeIndex >= badges.Length)
        {
            Debug.LogError("Invalid badge index");
            return;
        }
        if (badges[badgeIndex].amountOfBadges > 0 && badges[badgeIndex].amountOfBadgesEquipped < badgeSlots)
        {
            print("Activating badge: " + badges[badgeIndex].badgeName);
            PlayerStats playerStats = GetComponent<PlayerStats>();

            playerStats.ammoCount = Mathf.RoundToInt(playerStats.ammoCount * badges[badgeIndex].ammoMultiplier);
            playerStats.reloadTime = playerStats.reloadTime * badges[badgeIndex].reloadSpeed;
            playerStats.regenAmount = Mathf.RoundToInt(playerStats.regenAmount * badges[badgeIndex].regenAmountMultiplier);
            playerStats.maxHealth = Mathf.RoundToInt(playerStats.maxHealth * badges[badgeIndex].maxHealthMultiplier);
            playerStats.damage = Mathf.RoundToInt(playerStats.damage * badges[badgeIndex].damageMultiplier);

            // Decrease the amount of this badge
            badges[badgeIndex].amountOfBadges--;
            // Increase the amount of this badge equipped
            badges[badgeIndex].amountOfBadgesEquipped++;
        }
        else
        {
            Debug.Log("No more badges of this type left to activate.");
        }
    }

    public void DeactivateBadge(int badgeIndex)
    {
        if (badgeIndex < 0 || badgeIndex >= badges.Length)
        {
            Debug.LogError("Invalid badge index");
            return;
        }
        if (badges[badgeIndex].amountOfBadgesEquipped > 0)
        {
            PlayerStats playerStats = GetComponent<PlayerStats>();
            playerStats.ammoCount = Mathf.RoundToInt(playerStats.ammoCount / badges[badgeIndex].ammoMultiplier);
            playerStats.reloadTime = playerStats.reloadTime / badges[badgeIndex].reloadSpeed;
            playerStats.regenAmount = Mathf.RoundToInt(playerStats.regenAmount / badges[badgeIndex].regenAmountMultiplier);
            playerStats.maxHealth = Mathf.RoundToInt(playerStats.maxHealth / badges[badgeIndex].maxHealthMultiplier);
            playerStats.damage = Mathf.RoundToInt(playerStats.damage / badges[badgeIndex].damageMultiplier);
            // Increase the amount of this badge
            badges[badgeIndex].amountOfBadges++;
            // Decrease the amount of this badge equipped
            badges[badgeIndex].amountOfBadgesEquipped--;
        }
        else
        {
            Debug.Log("No more badges of this type equipped to deactivate.");
        }
    }
}
