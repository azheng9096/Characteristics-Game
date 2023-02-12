using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeChoice : MonoBehaviour
{
    Upgrade upgrade;

    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI descriptionText;

    GameObject selectionScreen;

    void Start() {
        selectionScreen = GameObject.FindGameObjectWithTag("SelectionUI");
    }

    public void SetUpgrade(Upgrade newUpgrade) {
        upgrade = newUpgrade;

        icon.sprite = upgrade.sprite;
        nameText.text = upgrade.upgradeName;

        int curr_qty = 0;
        if (UpgradesManager.instance.upgrades.ContainsKey(upgrade)) {
            curr_qty = UpgradesManager.instance.upgrades[upgrade];
        }

        descriptionText.text = upgrade.description + "<br><br>Currently Owned: " + (curr_qty.ToString());
    }

    public void OnClick() {
        if (upgrade != null)
            UpgradesManager.instance.Add(upgrade);
        else
            Debug.LogError("DEV_DEBUG_LOG_ERROR: Upgrade is null!");

        // close selection screen
        selectionScreen.SetActive(false);

        // TODO maybe generate choices for next level here
    }
}
