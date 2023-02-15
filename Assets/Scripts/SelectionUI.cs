using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionUI : MonoBehaviour
{
    public static SelectionUI instance;

    // upgrade type to be generated
    public SelectionUI.UpgradeType levelUpgradeType;

    // list of possible upgrades
    [SerializeField] Upgrade[] healUpgradesPool;
    [SerializeField] Upgrade[] statUpgradesPool;
    [SerializeField] Upgrade[] abilityUpgradesPool;

    // list of upgrade choices to display
    public List<Upgrade> upgrades = new List<Upgrade>();

    public delegate void OnUpgradeChoicesChanged();
    public OnUpgradeChoicesChanged onUpgradeChoicesChangedCallback;

    // UI
    [SerializeField] Transform ChoicesPanelTrans;
    [SerializeField] GameObject UpgradeChoicePrefab;

    [SerializeField] GameObject SelectionUICanvas;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        levelUpgradeType = Save.levelRewardType;

        onUpgradeChoicesChangedCallback += ListChoices;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpgradeChoices(List<Upgrade> choices) {
        upgrades = choices;

        onUpgradeChoicesChangedCallback?.Invoke();
    }

    public void AddUpgradeChoices(params Upgrade[] choices) {
        foreach (Upgrade choice in choices) {
            upgrades.Add(choice);
        }

        onUpgradeChoicesChangedCallback?.Invoke();
    }

    public void ListChoices() {
        foreach (Transform child in ChoicesPanelTrans) {
            Destroy(child.gameObject);
        }

        foreach (Upgrade upgrade in SelectionUI.instance.upgrades) {
            GameObject obj = Instantiate(UpgradeChoicePrefab, ChoicesPanelTrans);

            UpgradeChoice choiceSlot = obj.GetComponent<UpgradeChoice>();
            choiceSlot.SetUpgrade(upgrade);
        }
    }

    public void ToggleSelection(bool val) {
        SelectionUICanvas.SetActive(val);

        if (val)
            ListChoices();
    }

    public List<Upgrade> FilterUpgradeChoices(Upgrade[] pool) {
        List<Upgrade> okUpgrades = new List<Upgrade>();

        foreach (Upgrade upgrade in pool) {
            // upgrade can still be stacked
            if (!UpgradesManager.instance.upgrades.ContainsKey(upgrade) || UpgradesManager.instance.upgrades[upgrade] < upgrade.maxStack) {
                okUpgrades.Add(upgrade);
            }
        }

        return okUpgrades;
    }

    public void GenerateUpgradeChoices(UpgradeType upgradeType, int num) {
        // reset choices
        SetUpgradeChoices(new List<Upgrade>());

        switch (upgradeType) {
            case UpgradeType.Heal:
                List<Upgrade> okHealUpgrades = new List<Upgrade>(healUpgradesPool);

                for (int i = 0; i < num; i++) {
                    if (okHealUpgrades.Count > 0) {
                        int r = Random.Range(0, healUpgradesPool.Length);

                        AddUpgradeChoices(healUpgradesPool[r]);
                        okHealUpgrades.Remove(healUpgradesPool[r]);
                    }
                }

                break;
            case UpgradeType.Stat:
                // filter upgrade pool
                List<Upgrade> okStatUpgrades = FilterUpgradeChoices(statUpgradesPool);

                // generate stat upgrade choices
                for (int i = 0; i < num; i++) {
                    if (okStatUpgrades.Count > 0) {
                        int r = Random.Range(0, okStatUpgrades.Count);
                    
                        AddUpgradeChoices(okStatUpgrades[r]); // add to choices pool for user selection
                        okStatUpgrades.Remove(okStatUpgrades[r]);
                    }
                }

                break;
            case UpgradeType.Ability:
                //filter upgrade pool
                List<Upgrade> okAbilityUpgrades = FilterUpgradeChoices(abilityUpgradesPool);

                // generate ability upgrade choices
                for (int i = 0; i < num; i++) {
                    if (okAbilityUpgrades.Count > 0) {
                        int r = Random.Range(0, okAbilityUpgrades.Count);

                        AddUpgradeChoices(okAbilityUpgrades[r]); // add to choices pool for user selection
                        okAbilityUpgrades.Remove(okAbilityUpgrades[r]);
                    }
                }

                break;
            case UpgradeType.All:
                List<Upgrade> okUpgrades = FilterUpgradeChoices(statUpgradesPool);
                okUpgrades.AddRange(FilterUpgradeChoices(abilityUpgradesPool));
                okUpgrades.AddRange(healUpgradesPool);

                // generate ability upgrade choices
                for (int i = 0; i < num; i++) {
                    if (okUpgrades.Count > 0) {
                        int r = Random.Range(0, okUpgrades.Count);

                        AddUpgradeChoices(okUpgrades[r]); // add to choices pool for user selection
                        okUpgrades.Remove(okUpgrades[r]);
                    }
                }

                break;
        }
    }


    public void CloseSelection() {
        // close selection screen
        ToggleSelection(false);

        // generate and display choices for next level
        NextLevelUI.instance.ToggleSelection(true);
    }


    // NOTE call this upon victory of a stage
    public void DisplaySelection() {
        int num = Random.Range(2, 5);
        GenerateUpgradeChoices(levelUpgradeType, num);

        ToggleSelection(true);
    }

    public enum UpgradeType {Heal, Stat, Ability, All};
}
