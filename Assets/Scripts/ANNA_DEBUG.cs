using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANNA_DEBUG : MonoBehaviour
{
    [SerializeField] Upgrade flame;
    [SerializeField] Upgrade ice;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddFlame() {
        UpgradesManager.instance.Add(flame);
    }

    public void AddIce() {
        UpgradesManager.instance.Add(ice);
    }

    public void ShowRewards() {
        // SelectionUI.instance.GenerateUpgradeChoices(SelectionUI.UpgradeType.All, 2);
        // SelectionUI.instance.ToggleSelection(true); // toggle canvas

        SelectionUI.instance.DisplaySelection();
    }

    public void GameOver() {
        GameOverUI.instance.ToggleGameOverScreen(true);
    }

    public void KillEnemy() {
        GameObject enemyObj = GameObject.FindGameObjectWithTag("Enemy");

        if (enemyObj != null) {
            MonsterDamage enemy = enemyObj.GetComponent<MonsterDamage>();
            enemy.Die();
        }
        
    }
}
