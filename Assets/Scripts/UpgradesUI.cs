using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesUI : MonoBehaviour
{
    [SerializeField] Transform UpgradesPanelTrans;
    [SerializeField] GameObject UpgradeSlotPrefab;

    // Start is called before the first frame update
    void Start()
    {
        UpgradesManager.instance.onUpgradesChangedCallback += ListUpgrades;

        ListUpgrades();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void ListUpgrades() {
        foreach (Transform child in UpgradesPanelTrans) {
            Destroy(child.gameObject);
        }

        foreach (Upgrade upgrade in UpgradesManager.instance.upgrades.Keys) {
            GameObject obj = Instantiate(UpgradeSlotPrefab, UpgradesPanelTrans);

            UpgradeSlot upgradeSlot = obj.GetComponent<UpgradeSlot>();
            upgradeSlot.SetUpgrade(upgrade, UpgradesManager.instance.upgrades[upgrade]);
        }
    }
}
