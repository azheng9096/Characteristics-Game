using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using UnityEngine.SceneManagement;

public class NextLevelChoice : MonoBehaviour
{
    SelectionUI.UpgradeType upgradeType;

    // UI
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI nameText;

    [SerializeField] Sprite healSprite;
    [SerializeField] Sprite statSprite;
    [SerializeField] Sprite abilitySprite;
    [SerializeField] Sprite allSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpgrade(SelectionUI.UpgradeType newUpgradeType) {
        upgradeType = newUpgradeType;

        Sprite sprite = null;
        string upgradeTypeName = "";

        switch(upgradeType) {
            case SelectionUI.UpgradeType.Heal:
                sprite = healSprite;
                upgradeTypeName = "Healing";

                break;
            case SelectionUI.UpgradeType.Stat:
                sprite = statSprite;
                upgradeTypeName = "Stat Upgrade";

                break;
            case SelectionUI.UpgradeType.Ability:
                sprite = abilitySprite;
                upgradeTypeName = "Ability Upgrade";

                break;
            case SelectionUI.UpgradeType.All:
                sprite = allSprite;
                upgradeTypeName = "Mystery Upgrade";

                break;
        }

        icon.sprite = sprite;
        nameText.text = upgradeTypeName;
    }

    public void OnClick() {
        // save player data
        PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Save.SavePlayerData(player);

        // save next level upgrade
        Save.SaveLevelData(upgradeType);

        NextLevelUI.instance.ToggleSelection(false);

        // generate new level
        int r = Random.Range(0, NextLevelUI.instance.levelSceneIdPool.Length);
        int nextLevelId = NextLevelUI.instance.levelSceneIdPool[r];

        // load new level
        SceneManager.LoadScene(nextLevelId);
    }
}
