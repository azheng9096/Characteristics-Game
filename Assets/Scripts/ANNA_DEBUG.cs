using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANNA_DEBUG : MonoBehaviour
{
    [SerializeField] Upgrade pencil;
    [SerializeField] Upgrade brush;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddPencil() {
        UpgradesManager.instance.Add(pencil);
    }

    public void AddBrush() {
        UpgradesManager.instance.Add(brush);
    }

    public void ShowRewards() {
        // SelectionUI.instance.GenerateUpgradeChoices(SelectionUI.UpgradeType.All, 2);
        // SelectionUI.instance.ToggleSelection(true); // toggle canvas

        SelectionUI.instance.DisplaySelection();
    }

    public void GameOver() {
        GameOverUI.instance.ToggleGameOverScreen(true);
    }
}
