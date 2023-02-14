using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    public int damage;
    public float health = 100;
    
    PlayerController damages;
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

        else if (collision.gameObject.CompareTag("Bullet")){
            float damage = player.returnDamage();
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
        }
    }
    public void Die() // made public for debugging purposes
    {
        GameOverUI.instance.DeductEnemyCount();
        Destroy(gameObject);
    }
}
