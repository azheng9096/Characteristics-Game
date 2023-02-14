using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI instance;

    [SerializeField] GameObject GameOverUICanvas;
    [SerializeField] GameObject VictoryUICanvas;

    bool gameOver = false;
    int numEnemies = 9999;

    void Awake()
    {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        EvaluateNextStep();
    }

    public void ToggleGameOverScreen(bool val) {
        GameOverUICanvas.SetActive(val);
    }

    public void ToggleVictoryScreen(bool val) {
        VictoryUICanvas.SetActive(val);
    }

    public void OnClick() {
        // reset progress
        Save.ResetData();

        // generate new level
        int r = Random.Range(0, NextLevelUI.instance.levelSceneIdPool.Length);
        int nextLevelId = NextLevelUI.instance.levelSceneIdPool[r];

        // load new level
        SceneManager.LoadScene(nextLevelId);
    }

    public void InitGame(int enemyCount) {
        gameOver = false;
        numEnemies = enemyCount;
    }

    public void DeductEnemyCount() {
        numEnemies--;
    }

    public void EvaluateNextStep() {
        // level complete
        if (!gameOver && numEnemies <= 0) {
            gameOver = true;
            
            // final level
            if (Save.currLevel == Save.maxLevel) {
                ToggleVictoryScreen(true);
            } else {
                SelectionUI.instance.DisplaySelection();
            }
        }
    }
}
