using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float health;
    public float maxHealth;    
    public float movementSpeed;


    public Transform RANGEDPOINT;
    public GameObject bullet;
    public float atkSpeed;
    public float atkPower = 30f;

    public AudioSource shootingNoise;

    Rigidbody2D rb;

    public delegate void OnHealthChangedDelegate();
    public event OnHealthChangedDelegate OnHealthChanged;


    // abilities
    public int flameStack = 0;
    public int iceStack = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shootingNoise = GetComponent<AudioSource>();
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
            shootingNoise.Play();
        }
    }

    public void Shoot()
    {
        GameObject bullts = Instantiate(bullet, RANGEDPOINT.position, RANGEDPOINT.rotation);
        Rigidbody2D rb = bullts.GetComponent<Rigidbody2D>();
        rb.AddForce(RANGEDPOINT.up * atkSpeed, ForceMode2D.Impulse);
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
        flameStack = Save.flameStack;
        iceStack = Save.iceStack;
    }

    public float returnDamage(){
        return atkPower;
    }
}
