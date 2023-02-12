using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float health = 75f;
    public float maxHealth = 100f;
    
    public float atkspeed = 1f;
    public float movementSpeed = 7.5f;
    
    Rigidbody2D rb;


    public delegate void OnHealthChangedDelegate();
    public event OnHealthChangedDelegate OnHealthChanged;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        
        rb.velocity = new Vector2(xInput, yInput).normalized * movementSpeed;

        // player face mouse direction
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // health
        health = Mathf.Clamp(health, 0, maxHealth);

        /* // DEBUG
            if (Input.GetKeyDown(KeyCode.M)) {
                TakeDamage(Random.Range(5, 10));
            }

            if (Input.GetKeyDown(KeyCode.N)) {
                RestoreHealth(Random.Range(5, 10));
            }

            if (Input.GetKeyDown(KeyCode.B)) {
                IncreaseMaxHealth(Random.Range(5, 10));
            }

            if(Input.GetKeyDown(KeyCode.V)) {
                DecreaseMaxHealth(Random.Range(5 ,10));
            }
        */
    }

    public void TakeDamage(float dmg) {
        health -= dmg;

        OnHealthChanged?.Invoke();
    }

    public void RestoreHealth(float healAmt) {
        health += healAmt;

        OnHealthChanged?.Invoke();
    }

    public void IncreaseMaxHealth(float incAmt) {
        maxHealth += incAmt;
        health += incAmt;
        
        OnHealthChanged?.Invoke();
    }

    public void DecreaseMaxHealth(float decAmt) {
        maxHealth -= decAmt;
        
        if (maxHealth < health) {
            health = maxHealth;
        }

        OnHealthChanged?.Invoke();
    }
}
