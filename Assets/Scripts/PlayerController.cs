using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float health = 75f;
    public float maxHealth = 100f;    
    public float movementSpeed = 7.5f;


    public Transform RANGEDPOINT;
    public GameObject bullet;
    public float bulletForce;

    public float atkPower = 20f;
    public float atkSpeed = 1f;
    
    


    Rigidbody2D rb;

    public delegate void OnHealthChangedDelegate();
    public event OnHealthChangedDelegate OnHealthChanged;


    // abilities
    public bool EnableFlame;
    public bool EnableIce;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        LoadData();
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


        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject bullts = Instantiate(bullet, RANGEDPOINT.position, RANGEDPOINT.rotation);
        Rigidbody2D rb = bullts.GetComponent<Rigidbody2D>();
        rb.AddForce(RANGEDPOINT.up * bulletForce, ForceMode2D.Impulse);
    }

    public void TakeDamage(float dmg) {
        health -= dmg;

        OnHealthChanged?.Invoke();

        if (health <= 0) {
            GameOverUI.instance.ToggleGameOverScreen(true);
            Destroy(gameObject);
        }
    }

    public void RestoreHealth(float healAmt) {
        health += healAmt;

        OnHealthChanged?.Invoke();
    }

    public void ChangeMaxHealth(float changeAmt) {
        maxHealth += changeAmt;

        if (maxHealth < health) {
            health = maxHealth;
        } else {
            health += changeAmt;
        }
        
        OnHealthChanged?.Invoke();
    }

    public void LoadData() {
        health = Save.health;
        maxHealth = Save.maxHealth;
        atkPower = Save.atkPower;
        atkSpeed = Save.atkSpeed;
        movementSpeed = Save.movementSpeed;
    }
}
