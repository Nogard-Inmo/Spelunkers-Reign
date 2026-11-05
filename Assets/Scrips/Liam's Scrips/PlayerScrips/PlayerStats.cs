using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Base stats/current values
    public int ammoCount;
    public float reloadTime;
    public int regenAmount;
    public int damage;
    public float speed;
    public int maxHealth;

    //Multipliers for upgrades
    public float ammoMultiplier = 1f;
    public float reloadSpeed = 1f;
    public float regenAmountMultiplier = 1f;
    public float maxHealthMultiplier = 1.0f;
    public float damageMultiplier = 1.0f;

    int[] currentUpgradeLevel = new int[5]; // 0: Ammo, 1: Reload, 2: Regen, 3: Max Health, 4: Damage

    //debugging purposes
    public GameObject debugMenu;
    public KeyCode debugMenuKey = KeyCode.F1;

    private void Update()
    {
        if (Input.GetKeyDown(debugMenuKey))
        {
            debugMenu.SetActive(!debugMenu.activeSelf);
        }
    }

    public void UpgradeStats(int upgradeIndex)
    {
        if(upgradeIndex < 0 || upgradeIndex >= currentUpgradeLevel.Length)
        {
            Debug.LogError("Invalid upgrade index");
            return;
        }
        else if (upgradeIndex == 0)
        {
            ammoCount = Mathf.RoundToInt(ammoCount * ammoMultiplier);
        }
        else if(upgradeIndex == 1)
        {
            reloadTime *= reloadSpeed;
        }
        else if (upgradeIndex == 2)
        {
            regenAmount = Mathf.RoundToInt(regenAmount * regenAmountMultiplier);
        }
        else if(upgradeIndex == 3)
        {
            maxHealth = Mathf.RoundToInt(maxHealth * maxHealthMultiplier);
        }
        else if(upgradeIndex == 4)
        {
            damage = Mathf.RoundToInt(damage * damageMultiplier);
        }
    }
}
