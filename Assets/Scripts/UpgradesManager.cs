using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    public static UpgradesManager instance;

    public Dictionary<Upgrade, int> upgrades = new Dictionary<Upgrade, int>();

    public delegate void OnUpgradesChanged();
    public OnUpgradesChanged onUpgradesChangedCallback;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void Add(Upgrade upgrade) {
        if(!upgrades.ContainsKey(upgrade)) {
            upgrades.Add(upgrade, 0); // initialize count
        }

        upgrades[upgrade]++;
        Debug.Log("Added " + upgrade.upgradeName + ", curr qty: " + upgrades[upgrade]);

        upgrade.Use();

        onUpgradesChangedCallback?.Invoke();
    }

    public void RemoveAll(Upgrade upgrade) {
        // disable its effects on the player
        for (int i = 0; i < upgrades[upgrade]; i++) {
            upgrade.Remove();
        }

        upgrades.Remove(upgrade);

        onUpgradesChangedCallback?.Invoke();
    }
}
