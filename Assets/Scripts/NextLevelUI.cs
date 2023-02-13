using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelUI : MonoBehaviour
{
    public static NextLevelUI instance;

    public List<SelectionUI.UpgradeType> upgradeTypesPool;

    [SerializeField] Transform NextLevelChoicesPanelTrans;
    [SerializeField] GameObject NextLevelChoicePrefab;

    [SerializeField] GameObject NextLevelUICanvas;

    public int[] levelSceneIdPool;

    
    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void ListChoices() {
        foreach (Transform child in NextLevelChoicesPanelTrans) {
            Destroy(child.gameObject);
        }

        int num = Random.Range(1, upgradeTypesPool.Count + 1);
        List<SelectionUI.UpgradeType> u = GenerateNextLevelChoices(num);

        foreach (SelectionUI.UpgradeType upgradeType in u) {
            GameObject obj = Instantiate(NextLevelChoicePrefab, NextLevelChoicesPanelTrans);

            NextLevelChoice choiceSlot = obj.GetComponent<NextLevelChoice>();
            choiceSlot.SetUpgrade(upgradeType);
        }
    }

    public void ToggleSelection(bool val) {
        NextLevelUICanvas.SetActive(val);

        if (val)
            ListChoices();
    }

    public List<SelectionUI.UpgradeType> GenerateNextLevelChoices(int num) {
        List<SelectionUI.UpgradeType> uPool = new List<SelectionUI.UpgradeType>();
        uPool.AddRange(upgradeTypesPool);

        List<SelectionUI.UpgradeType> u = new List<SelectionUI.UpgradeType>();
        for (int i = 0; i < num; i++) {
            int r = Random.Range(0, uPool.Count);

            u.Add(uPool[r]);
            uPool.Remove(uPool[r]);
        }

        return u;
    }
}
