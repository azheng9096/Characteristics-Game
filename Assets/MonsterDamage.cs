using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterDamage : MonoBehaviour
{
    public float damage;
    private bool invincible = false;
    public float health = 100;
    public bool explodeOnImpact;
    // public PlayerHealth playerHealth;

    PlayerController player;
    ColoredFlash flash;

    public AudioSource damageNoise;


    [SerializeField] GameObject FlameParticleEffect;

    float maxHealth;
    [SerializeField] Slider healthBar;
    
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        damage *= Save.currLevel;
        health *= Save.currLevel;

        maxHealth = health;
        SetMaxHealthUI();

        damageNoise = GetComponent<AudioSource>();

    }

    void SetMaxHealthUI() {
        if (healthBar != null) {
            healthBar.maxValue = maxHealth;
            healthBar.value = health;
        }
    }
    void SetHealthUI() {
        if (healthBar != null) 
            healthBar.value = health;
    }

    private void OnCollisionStay2D(Collision2D collision){
        if (collision.gameObject.tag == "Player" && !invincible){
            // playerHealth.TakeDamage(damage);
            player.TakeDamage(damage);
            invincible = true;
            StartCoroutine("Invulnerable");
            if (explodeOnImpact){
                Die();
            }
        }
    }

    IEnumerator Invulnerable(){
        yield return new WaitForSeconds(0.3f);
        invincible = false;
    }

    private void OnCollisionExit2D(Collision2D collision){

    }

    public void TakeDamage(float dmg) {
        health -= dmg;
        damageNoise.Play()
        if (health <= 0) {
            Die();
        }

        SetHealthUI();
    }

    bool dead = false;
    public void Die() // made public for debugging purposes
    {
        if (!dead) { // prevent deduct enemy count more than once
            dead = true;
            GameOverUI.instance.DeductEnemyCount();
        }
        Destroy(gameObject);
    }


    public IEnumerator TakeDamagePerSecond(float dmg) {
        while (true) {
            TakeDamage(dmg);
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator IgniteCoroutine(float dmg, float duration) {
        Coroutine takeDmgCoroutine = StartCoroutine(TakeDamagePerSecond(dmg));
        FlameParticleEffect.SetActive(true);

        yield return new WaitForSeconds(duration);

        StopCoroutine(takeDmgCoroutine);
        FlameParticleEffect.SetActive(false);
    }

    public void Ignite(float dmg, float duration) {
        StartCoroutine(IgniteCoroutine(dmg, duration));
    }
}
