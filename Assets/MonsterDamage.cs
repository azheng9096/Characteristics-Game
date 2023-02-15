using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    public float damage;
    private bool invincible = false;
    public float health = 100;
    // public PlayerHealth playerHealth;

    PlayerController player;
    ColoredFlash flash;
    
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        damage *= Save.currLevel;
        health *= Save.currLevel;
    }

    private void OnCollisionStay2D(Collision2D collision){
        if (collision.gameObject.tag == "Player" && !invincible){
            // playerHealth.TakeDamage(damage);
            player.TakeDamage(damage);
            invincible = true;
            StartCoroutine("Invulnerable");
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

        if (health <= 0) {
            Die();
        }
    }

    public void Die() // made public for debugging purposes
    {
        GameOverUI.instance.DeductEnemyCount();
        Destroy(gameObject);
    }
}
