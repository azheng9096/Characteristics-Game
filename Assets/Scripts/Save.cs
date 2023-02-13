using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Save {
    public static float health = 100f;
    public static float maxHealth = 100f;
    public static float atkPower = 20f;
    public static float atkSpeed = 1f;
    public static float movementSpeed = 7.5f;

    public static Dictionary<Upgrade, int> upgrades = new Dictionary<Upgrade, int>();

    // for next level
    public static SelectionUI.UpgradeType levelRewardType = SelectionUI.UpgradeType.Stat;


    public static void SavePlayerData(PlayerController playerController) {
        health = playerController.health;
        maxHealth = playerController.maxHealth;
        atkPower = playerController.atkPower;
        atkSpeed = playerController.atkSpeed;
        movementSpeed = playerController.movementSpeed;

        upgrades = UpgradesManager.instance.upgrades;
    }

    public static void SaveLevelData(SelectionUI.UpgradeType nextLevelRewardType) {
        levelRewardType = nextLevelRewardType;
    }
    
    public static void ResetData() {
        health = 100f;
        maxHealth = 100f;
        atkPower = 20f;
        atkSpeed = 1f;
        movementSpeed = 7.5f;

        upgrades = new Dictionary<Upgrade, int>();

        levelRewardType = SelectionUI.UpgradeType.Stat;
    }
}
