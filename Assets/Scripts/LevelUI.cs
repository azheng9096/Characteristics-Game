using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class LevelUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText;

    // Start is called before the first frame update
    void Start()
    {
        if (Save.currLevel < Save.maxLevel) {
            levelText.text = "Level " + Save.currLevel.ToString();
        } else {
            levelText.text = "Final Level";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
