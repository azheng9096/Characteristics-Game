using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeSlot : MonoBehaviour
{
    Upgrade upgrade;
    int qty;

    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI qtyText;

    public void SetUpgrade(Upgrade newUpgrade, int newQty) {
        upgrade = newUpgrade;
        qty = newQty;

        icon.sprite = upgrade.sprite;
        qtyText.text = qty.ToString();
    }
}
