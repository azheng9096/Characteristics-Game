using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI instance;

    [SerializeField] GameObject GameOverUICanvas;

    // Start is called before the first frame update
    void Start()
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
        
    }

    // call this to toggle game over ui
    public void ToggleGameOverScreen(bool val) {
        GameOverUICanvas.SetActive(val);
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
}
