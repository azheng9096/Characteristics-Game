using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] PlayerController player;

    float lerpTimer;
    [SerializeField] float chipSpeed = 3f;
    [SerializeField] Image chipBar;
    [SerializeField] Image fillBar;

    // Start is called before the first frame update
    void Start()
    {
        player.OnHealthChanged +=  ResetLerpTimer;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthUI();
    }

    public void UpdateHealthUI() {
        float fillC = chipBar.fillAmount;
        float fillF = fillBar.fillAmount;
        float hFraction = player.health / player.maxHealth;

        if (fillC > hFraction) {
            fillBar.fillAmount = hFraction;
            
            Color color;
            if (ColorUtility.TryParseHtmlString("#7B1C1C", out color)) {
                chipBar.color = color;
            } else {
                chipBar.color = Color.red;
            }

            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            chipBar.fillAmount = Mathf.Lerp(fillC, hFraction, percentComplete);
        } else if (fillF < hFraction) {
            chipBar.fillAmount = hFraction;

            Color color;
            if (ColorUtility.TryParseHtmlString("#7EDE98", out color)) {
                chipBar.color = color;
            } else {
                chipBar.color = Color.blue;
            }

            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            fillBar.fillAmount = Mathf.Lerp(fillF, hFraction, percentComplete);
        }
    }

    public void ResetLerpTimer() {
        lerpTimer = 0f;
    }
}
