using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    public int damage;
    public int health = 100;
    // public PlayerHealth playerHealth;

    PlayerController player;
    
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player"){
            // playerHealth.TakeDamage(damage);
            player.TakeDamage(damage);
        }

    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Bullet")){
            health -= damage;
        }
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die() // made public for debugging purposes
    {
        GameOverUI.instance.DeductEnemyCount();
        Destroy(gameObject);
    }
}
