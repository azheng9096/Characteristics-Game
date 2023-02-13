using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    public int damage;
    public int health = 100;
    public PlayerHealth playerHealth;

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player"){
            playerHealth.TakeDamage(damage);
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

    void Die()
    {
        Destroy(gameObject);
    }
}
