using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Save {
    public static float health = 100f;
    public static float maxHealth = 100f;
    public static float atkPower = 30f;
    public static float atkSpeed = 12f;
    public static float movementSpeed = 7.5f;
    public static int flameStack = 0;
    public static int iceStack = 0;


    public static int currLevel = 1;
    public static int maxLevel = 5;

    public static Dictionary<Upgrade, int> upgrades = new Dictionary<Upgrade, int>();

    // for next level
    public static SelectionUI.UpgradeType levelRewardType = SelectionUI.UpgradeType.Stat;


    public static void SavePlayerData(PlayerController playerController) {
        health = playerController.health;
        maxHealth = playerController.maxHealth;
        atkPower = playerController.atkPower;
        atkSpeed = playerController.atkSpeed;
        movementSpeed = playerController.movementSpeed;

        flameStack = playerController.flameStack;
        iceStack = playerController.iceStack;

        upgrades = UpgradesManager.instance.upgrades;
    }

    public static void SaveLevelData(SelectionUI.UpgradeType nextLevelRewardType) {
        currLevel++;
        levelRewardType = nextLevelRewardType;
    }
    
    public static void ResetData() {
        health = 100f;
        maxHealth = 100f;
        atkPower = 20f;
        atkSpeed = 12f;
        movementSpeed = 7.5f;

        flameStack = 0;
        iceStack = 0;

        currLevel = 1;

        upgrades = new Dictionary<Upgrade, int>();

        levelRewardType = SelectionUI.UpgradeType.Stat;
    }
}
